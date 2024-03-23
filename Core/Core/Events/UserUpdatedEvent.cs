namespace Core.Events
{
    public class UserUpdatedEvent
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int CountryCode { get; set; }

        public string City { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
