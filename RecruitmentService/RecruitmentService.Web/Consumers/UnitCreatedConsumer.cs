using Core.Events;
using MassTransit;
using RecruitmentService.Application.Interfaces;

namespace RecruitmentService.Web.Consumers
{
    public class UnitCreatedConsumer : IConsumer<UnitCreatedEvent>
    {
        private readonly IDivisionsService _divisionsService;
        
        public UnitCreatedConsumer(
            IDivisionsService divisionsService)
        {
            _divisionsService = divisionsService;
        }

        public async Task Consume(ConsumeContext<UnitCreatedEvent> context)
        {
            await _divisionsService.CreateAsync(
                context.Message.UnitId,
                context.Message.CompanyId,
                context.Message.LeadId,
                context.CancellationToken);
        }
    }
}
