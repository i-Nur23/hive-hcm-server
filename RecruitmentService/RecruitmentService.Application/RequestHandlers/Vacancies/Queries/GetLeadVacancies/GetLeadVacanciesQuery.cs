using MediatR;
using RecruitmentService.Application.Common.Vms.Vacancies;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetLeadVacancies
{
    public class GetLeadVacanciesQuery : IRequest<VacanciesVm> 
    {
        public Guid LeadId { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }
    }
}
