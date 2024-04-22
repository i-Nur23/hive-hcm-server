using AutoMapper;
using MediatR;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;
using RecruitmentService.Domain.Enums;

namespace RecruitmentService.Application.RequestHandlers.Responses.Commands.AddResponse
{
    public class AddResponseCommandHandler : 
        BaseRequestHandler,
        IRequestHandler<AddResponseCommand, Unit>
    {
        public AddResponseCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            AddResponseCommand request, 
            CancellationToken cancellationToken)
        {
            Response response = _mapper.Map<Response>(request.Response);

            response.Id = Guid.NewGuid();
            response.Status = ResponseStatus.NotProcessed;
            response.UpdatedAt = DateTime.UtcNow;

            await _dbContext.Responses.AddAsync(response, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
