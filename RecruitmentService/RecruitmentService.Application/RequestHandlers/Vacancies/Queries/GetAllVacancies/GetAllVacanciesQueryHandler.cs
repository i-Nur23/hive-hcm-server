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
                .Where(v => v.HrId.Equals(request.HrId))
                .ProjectTo<VacancyVM>(_mapper.ConfigurationProvider)
                .Skip((request.Page - 1) * request.Limit)
                .Take(request.Limit)
                .ToList();

            return new VacanciesVm
            {
                Vacancies = vacancies,
                TotalCount = vacancies.Count()
            };
        }
    }
}
