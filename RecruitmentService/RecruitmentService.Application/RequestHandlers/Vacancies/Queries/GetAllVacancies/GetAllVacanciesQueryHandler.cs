using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Common.Vms.Vacancies;
using RecruitmentService.Application.Interfaces;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetAllVacancies
{
    public class GetAllVacanciesQueryHandler : 
        BaseRequestHandler,
        IRequestHandler<GetAllVacanciesQuery, VacanciesVm>
    {
        public GetAllVacanciesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<VacanciesVm> Handle(
            GetAllVacanciesQuery request, 
            CancellationToken cancellationToken)
        {
            IEnumerable<VacancyVM> vacancies = _dbContext.Vacancies
                .Include(v => v.Division)
                .Include(v => v.Responses)
                .ThenInclude(r => r.Candidate)
                .Where(v => v.Division.CompanyId.Equals(request.CompanyId))
                .ProjectTo<VacancyVM>(_mapper.ConfigurationProvider)
                .ToList();

            return new VacanciesVm
            {
                Vacancies = vacancies,
                TotalCount = vacancies.Count()
            };
        }
    }
}
