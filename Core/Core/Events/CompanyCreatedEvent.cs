namespace Core.Events
{
    public class CompanyCreatedEvent
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }
    }
}
