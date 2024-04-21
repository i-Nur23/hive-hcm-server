using AutoMapper;
using MediatR;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.RequestHandlers.Vacancies.Commands.UpdateVacancy
{
    public class UpdateVacancyCommandHandler : 
        BaseRequestHandler,
        IRequestHandler<UpdateVacancyCommand, Unit>
    {
        public UpdateVacancyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) : 
            base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            UpdateVacancyCommand request, 
            CancellationToken cancellationToken)
        {
            Vacancy vacancy = _mapper.Map<Vacancy>(request.Vacancy);

            _dbContext.Vacancies.Update(vacancy);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
