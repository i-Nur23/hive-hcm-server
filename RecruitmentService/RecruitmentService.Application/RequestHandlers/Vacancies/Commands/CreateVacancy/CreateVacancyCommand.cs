using MediatR;
using RecruitmentService.Application.Common.Vms.Vacancies;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Commands.CreateVacancy
{
    public class CreateVacancyCommand : IRequest<Unit>
    {
        public VacancyVM Vacancy { get; set; }
    }
}
