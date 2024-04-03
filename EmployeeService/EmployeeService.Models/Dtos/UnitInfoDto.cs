namespace EmployeeService.Models.Dtos
{
    public class UnitInfoDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public WorkerBaseDto Lead { get; set; }

        public List<WorkerBaseDto> Workers { get; set; }

        public List<UnitInfoDto> ChildUnits { get; set; }
    }
}
