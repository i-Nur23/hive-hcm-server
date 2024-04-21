using MediatR;
using RecruitmentService.Application.Common.Vms.Vacancies;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Commands.UpdateVacancy
{
    public class UpdateVacancyCommand : IRequest<Unit>
    {
        public VacancyVM Vacancy { get; set; }
    }
}
