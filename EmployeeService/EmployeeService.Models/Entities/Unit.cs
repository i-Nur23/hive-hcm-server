using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.Models.Entities
{
    public class Unit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }

        [ForeignKey("Lead")]
        public Guid LeadId { get; set; }

        [ForeignKey("ParentUnit")]
        public Guid? ParentUnitId { get; set; }

        public Employee Lead { get; set; }

        public Company Company { get; set; }

        public Unit? ParentUnit { get; set; }

        public ICollection<Employee> Workers { get; set; }

        public List<EmployeeUnit> EmployeeUnits { get; set; }

        public ICollection<Unit> ChildUnits { get; set; }
    }
}
