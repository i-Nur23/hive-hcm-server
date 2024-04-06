namespace StudyService.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public ICollection<EmployeeCompetence> EmployeeCompetences { get; set; }

        public List<EmployeeCourse> EmployeeCourses { get; set; }

        public ICollection<Course> Courses { get; set; }


    }
}
