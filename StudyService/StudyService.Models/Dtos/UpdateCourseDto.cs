namespace StudyService.Models.Dtos
{
    public class UpdateCourseDto
    {
        public Guid CourseId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<Guid> StudentIds { get; set; }
    }
}
