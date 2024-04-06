namespace StudyService.Models.Entities
{
    public class EmployeeCourse
    {
        public Guid EmployeeId { get; set; }

        public Guid CourseId { get; set; }

        public Employee Employee { get; set; }

        public Course Course { get; set; }
    }
}
