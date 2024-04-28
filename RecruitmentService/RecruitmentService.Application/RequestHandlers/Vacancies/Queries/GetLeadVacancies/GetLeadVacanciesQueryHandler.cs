using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Common.Vms.Vacancies;
using RecruitmentService.Application.Interfaces;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetLeadVacancies
{
    public class GetLeadVacanciesQueryHandler : 
        BaseRequestHandler,
        IRequestHandler<GetLeadVacanciesQuery, LeadVacanciesVM>
    {
        public GetLeadVacanciesQueryHandler(IApplicationDbContext dbContext, IMapper mapper) 
            : base (dbContext, mapper) { }

        public async Task<LeadVacanciesVM> Handle(
            GetLeadVacanciesQuery request, 
            CancellationToken cancellationToken)
        {
            IEnumerable<LeadVacancyVM> vacancies = _dbContext.Vacancies
                .Include(v => v.Division)
                .Include(v => v.Responses)
                .ThenInclude(r => r.Candidate)
                .Where(v => v.Division.LeadId.Equals(request.LeadId))
                .ProjectTo<LeadVacancyVM>(_mapper.ConfigurationProvider)
                .ToList();

            return new LeadVacanciesVM
            {
                Vacancies = vacancies,
                TotalCount = vacancies.Count()
            };
        }
    }
}
