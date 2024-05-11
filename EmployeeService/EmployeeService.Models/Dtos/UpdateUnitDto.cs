namespace EmployeeService.Models.Dtos
{
    public class UpdateUnitDto
    {
        public Guid UnitId { get; set; }

        public Guid LeadId { get; set; }

        public string Name { get; set; }
    }
}
