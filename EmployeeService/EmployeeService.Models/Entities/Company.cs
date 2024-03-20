namespace EmployeeService.Models.Entities
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Unit> Units {  get; set; }
    }
}
