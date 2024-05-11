using Core.Enums;

namespace EmployeeService.Models.Dtos
{
    public class WorkerBaseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public EmployeeStatus Status { get; set; }
    }
}
