namespace EmployeeService.Models.Dtos
{
    public class NewUnitDto
    {
        public Guid? ParentId { get; set; }

        public string Name { get; set; }

        public Guid LeadId { get; set; }
    }
}
