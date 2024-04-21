using AutoMapper;
using MediatR;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Commands.DeleteVacancy
{
    public class DeleteVacancyCommandHandler : 
        BaseRequestHandler,
        IRequestHandler<DeleteVacancyCommand, Unit>
    {
        public DeleteVacancyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) :
            base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            DeleteVacancyCommand request, 
            CancellationToken cancellationToken)
        {
            Vacancy vacancy = new Vacancy { Id = request.VacancyId };
            _dbContext.Vacancies.Attach(vacancy);
            _dbContext.Vacancies.Remove(vacancy);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
