using AutoMapper;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentService.Application.Common;
using RecruitmentService.Application.Interfaces;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.RequestHandlers.Responses.Commands.ChangeStatus
{
    public class ChangeStatusCommandHandler :
        BaseRequestHandler,
        IRequestHandler<ChangeStatusCommand, Unit>
    {
        public ChangeStatusCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<Unit> Handle(
            ChangeStatusCommand request, 
            CancellationToken cancellationToken)
        {
            Response response = await _dbContext.Responses
                .FirstOrDefaultAsync(r => r.Id.Equals(request.ResponseId));

            if (response == null)
            {
                throw new BadRequestException("Отклик не найден");
            }

            response.Status = request.NewStatus;
            response.UpdatedAt = DateTime.UtcNow;

            _dbContext.Responses.Update(response);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
