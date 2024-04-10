namespace StudyService.Models.Dtos
{
    public class AdminCourseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<StudentDto> Students { get; set; }
    }
}
