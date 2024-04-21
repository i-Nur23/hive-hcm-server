using MediatR;
using RecruitmentService.Application.Common.Vms.Vacancies;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetAllVacancies
{
    public class GetAllVacanciesQuery : IRequest<VacanciesVm>
    {
        public Guid HrId { get; set; }

        public int Limit { get; set; }

        public int Page { get; set; }
    }
}
