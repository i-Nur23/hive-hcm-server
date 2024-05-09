using AutoMapper;
using Core.Enums;
using Core.Events;
using Core.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Enums;
using ResponseEntity = RecruitmentService.Domain.Entities.Response;

namespace RecruitmentService.Application.RequestHandlers.Responses.Commands.HireCandidate
{
    public class HireCandidateCommandHandler :
        BaseRequestHandler,
        IRequestHandler<HireCandidateCommand, Unit>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public HireCandidateCommandHandler(
            IApplicationDbContext dbContext, 
            IMapper mapper,
            IPublishEndpoint publishEndpoint) : base(dbContext, mapper)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(
            HireCandidateCommand request, 
            CancellationToken cancellationToken)
        {
            ResponseEntity? response = await _dbContext.Responses
                .Include(response => response.Candidate)
                .Include(response => response.Vacancy)
                .ThenInclude(vacancy => vacancy.Division)
                .FirstOrDefaultAsync(
                    response => response.CandidateId.Equals(request.Id),
                    cancellationToken);

            if (response is null)
            {
                throw new BadRequestException("Отклик с таким ID не найден");
            }

            response.Status = ResponseStatus.Accepted;
            response.UpdatedAt = DateTime.UtcNow;
            _dbContext.Responses.Update(response);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _publishEndpoint.Publish(new CandidateHireEvent
            {
                Id = request.Id,
                Name = response.Candidate.Name,
                Surname = response.Candidate.Surname,
                Email = response.Candidate.Email,
                BirthDate = response.Candidate.BirthDate,
                Role = request.IsHr ? Role.HR : Role.Worker,
                CompanyId = response.Vacancy.Division.CompanyId,
                UnitId = response.Vacancy.Division.Id,
            });

            return Unit.Value;
        }
    }
}
