namespace Core.Events
{
    public class UnitUpdatedEvent
    {
        public Guid UnitId { get; set; }

        public Guid LeadId { get; set; }

        public string Name { get; set; }
    }
}
