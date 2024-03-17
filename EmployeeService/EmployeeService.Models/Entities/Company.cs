namespace EmployeeService.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Unit> Units {  get; set; }
    }
}
