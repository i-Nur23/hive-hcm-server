using Core.Enums;

namespace Core.Events
{
    public class NewUserEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set;}

        public string Surname { get; set; }

        public string Email { get; set; }

        public Guid CompanyId { get; set; }

        public Role Role { get; set; }
    }
}
