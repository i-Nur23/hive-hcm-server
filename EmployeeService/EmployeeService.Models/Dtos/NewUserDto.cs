using Core.Enums;

namespace EmployeeService.Models.Dtos
{
    public class NewUserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Guid UnitId { get; set; }

        public Role Role { get; set; }

    }
}
