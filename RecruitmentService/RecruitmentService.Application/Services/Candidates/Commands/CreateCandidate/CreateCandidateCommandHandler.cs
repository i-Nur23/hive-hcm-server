using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Services.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommandHandler : 
        BaseRequestHandler,
        IRequestHandler<CreateCandidateCommand, Unit>
    {
        private readonly ILogger<CreateCandidateCommandHandler> _logger;

        public CreateCandidateCommandHandler(
            IApplicationDbContext dbContext,
            ILogger<CreateCandidateCommandHandler> logger,
            IMapper mapper) : base (dbContext, mapper)
        {
            _logger = logger;
        }

        public async Task<Unit> Handle(
            CreateCandidateCommand request, 
            CancellationToken cancellationToken)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    Guid userId = Guid.NewGuid();

                    Candidate candidate = _mapper.Map<Candidate>(request.CreateCandidateDto);

                    candidate.Id = userId;

                    await _dbContext.Candidates.AddAsync(candidate);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    List<Job> jobs = request.CreateCandidateDto.Jobs
                        .AsQueryable()
                        .ProjectTo<Job>(_mapper.ConfigurationProvider)
                        .ToList();
                    
                    jobs.ForEach(job => job.CandidateId = userId);

                    await _dbContext.Jobs.AddRangeAsync(jobs, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    transaction.Commit();

                    return Unit.Value;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw new BadRequestException("Ошибка добавления кандидата");
                } 
            }            
        }
    }
}
