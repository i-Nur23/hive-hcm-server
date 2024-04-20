using Core.Events;
using MassTransit;
using MassTransit.Mediator;
using RecruitmentService.Application.Services.Divisions.Commands.CreateDivision;

namespace RecruitmentService.Web.Consumers
{
    public class UnitCreatedConsumer : IConsumer<UnitCreatedEvent>
    {
        private readonly IMediator _mediator;

        public UnitCreatedConsumer(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UnitCreatedEvent> context)
        {
            var command = new CreateDivisionCommand
            {
                UnitId = context.Message.UnitId,
                CompanyId = context.Message.CompanyId,
                LeadId = context.Message.LeadId,
            };

            await _mediator.Send(command, context.CancellationToken);
        }
    }
}
