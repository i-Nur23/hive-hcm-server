using System.ComponentModel.DataAnnotations.Schema;

namespace StudyService.Models.Entities
{
    public class Course
    {
        public Guid Id { get; set; }

        public Guid? InitiatorId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey("InitiatorId")]
        public Employee? Initiator { get; set; }

        public List<EmployeeCourse> EmployeeCourses { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
