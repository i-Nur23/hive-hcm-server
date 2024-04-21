using MediatR;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Commands.DeleteVacancy
{
    public class DeleteVacancyCommand : IRequest<Unit>
    {
        public Guid VacancyId { get; set; }
    }
}
