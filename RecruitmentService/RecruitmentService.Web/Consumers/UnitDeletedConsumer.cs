using Core.Events;
using MassTransit;
using RecruitmentService.Application.Interfaces;

namespace RecruitmentService.Web.Consumers
{
    public class UnitDeletedConsumer : IConsumer<UnitDeletedEvent>
    {
        private readonly IDivisionsService _divisionsService;

        public UnitDeletedConsumer(
            IDivisionsService divisionsService)
        {
            _divisionsService = divisionsService;
        }

        public async Task Consume(ConsumeContext<UnitDeletedEvent> context)
        {
            await _divisionsService.DeleteAsync(
                context.Message.UnitId,
                context.CancellationToken);
        }
    }
}
