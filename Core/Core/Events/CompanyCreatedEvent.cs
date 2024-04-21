namespace Core.Events
{
    public class CompanyCreatedEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public Guid CompanyId { get; set; }
    }
}
