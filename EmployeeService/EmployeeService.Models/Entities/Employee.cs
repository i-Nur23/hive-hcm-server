using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string? AvatarUrl { get; set; }

        public int? CountryCode { get; set; }

        public Guid CompanyId { get; set; }

        [ForeignKey("CountryCode")]
        public Country? Country { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public ICollection<Unit> Units { get; set; }

        public ICollection<Unit> LeadingUnits { get; set; }

        public List<EmployeeUnit> EmployeeUnits { get; set; }

        public Role RoleType { get; set; }

        [NotMapped]
        public string Role => $"{RoleType}";
    }
}
