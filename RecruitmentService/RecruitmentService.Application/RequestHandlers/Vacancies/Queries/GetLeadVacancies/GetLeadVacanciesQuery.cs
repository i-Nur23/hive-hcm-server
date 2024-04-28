using MediatR;
using RecruitmentService.Application.Common.Vms.Vacancies;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetLeadVacancies
{
    public class GetLeadVacanciesQuery : IRequest<LeadVacanciesVM> 
    {
        public Guid LeadId { get; set; }
    }
}
