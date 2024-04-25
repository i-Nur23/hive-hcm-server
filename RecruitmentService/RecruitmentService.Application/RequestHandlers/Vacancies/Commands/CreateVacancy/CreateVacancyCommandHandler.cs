using AutoMapper;
using MediatR;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyCommandHandler : 
        BaseRequestHandler,
        IRequestHandler<CreateVacancyCommand, Unit>
    {
        public CreateVacancyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            CreateVacancyCommand request, 
            CancellationToken cancellationToken)
        {
            Vacancy vacancy = _mapper.Map<Vacancy>(request.Vacancy);

            vacancy.Id = Guid.NewGuid();

            await _dbContext.Vacancies.AddAsync(vacancy, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
