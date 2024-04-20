using Core.Events;
using MassTransit;
using MassTransit.Mediator;
using RecruitmentService.Application.Services.Divisions.Commands.DeleteDivision;

namespace RecruitmentService.Web.Consumers
{
    public class UnitDeletedConsumer : IConsumer<UnitDeletedEvent>
    {
        private readonly IMediator _mediator;

        public UnitDeletedConsumer(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UnitDeletedEvent> context)
        {
            var command = new DeleteDivisionCommand
            {
                UnitId = context.Message.UnitId
            };

            await _mediator.Send( 
                command, 
                context.CancellationToken);
        }
    }
}
