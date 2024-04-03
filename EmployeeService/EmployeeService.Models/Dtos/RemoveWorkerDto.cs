namespace EmployeeService.Models.Dtos
{
    public class RemoveWorkerDto
    {
        public Guid UnitId { get; set; }

        public Guid WorkerId { get; set; }
    }
}
