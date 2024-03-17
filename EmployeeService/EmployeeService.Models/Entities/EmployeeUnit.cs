namespace EmployeeService.Models.Entities
{
    public class EmployeeUnit
    {
        public int UnitId { get; set; }

        public int EmployeeId { get; set; }

        public Unit Unit { get; set; }

        public Employee Employee { get; set; }
    }
}