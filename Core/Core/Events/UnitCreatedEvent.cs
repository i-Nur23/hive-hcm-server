namespace Core.Events
{
    public class UnitCreatedEvent
    {
        public Guid UnitId { get; set; }

        public Guid LeadId { get; set; }

        public Guid CompanyId { get; set; }
    }
}
