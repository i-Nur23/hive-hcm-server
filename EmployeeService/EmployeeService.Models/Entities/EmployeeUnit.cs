namespace EmployeeService.Models.Entities
{
    public class EmployeeUnit
    {
        public Guid UnitId { get; set; }

        public Guid EmployeeId { get; set; }

        public Unit Unit { get; set; }

        public Employee Employee { get; set; }
    }
}