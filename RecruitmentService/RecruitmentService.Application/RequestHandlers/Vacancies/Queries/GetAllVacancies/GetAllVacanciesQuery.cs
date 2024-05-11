using MediatR;
using RecruitmentService.Application.Common.Vms.Vacancies;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetAllVacancies
{
    public class GetAllVacanciesQuery : IRequest<VacanciesVm>
    {
        public Guid CompanyId { get; set; }
    }
}
