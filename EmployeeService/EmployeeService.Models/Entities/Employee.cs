using Core.Enums;

namespace EmployeeService.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronimic { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? AvatarUrl { get; set; }

        public ICollection<Unit> Units { get; set; }

        public ICollection<Unit> LeadingUnits { get; set; }

        public List<EmployeeUnit> EmployeeUnits { get; set; }

        public Role Role { get; set; }
    }
}
