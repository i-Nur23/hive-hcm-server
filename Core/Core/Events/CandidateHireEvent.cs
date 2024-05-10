using Core.Enums;

namespace Core.Events
{
    public class CandidateHireEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public Guid UnitId { get; set; }

        public Guid CompanyId { get; set; }

        public Role Role { get; set; }
    }
}
