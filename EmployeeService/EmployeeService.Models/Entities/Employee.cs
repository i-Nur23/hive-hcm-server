using EmployeeService.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string? Patronimic { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string AvatarUrl { get; set; }

        [ForeignKey("Comapny")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public Role Role { get; set; }
    }
}
