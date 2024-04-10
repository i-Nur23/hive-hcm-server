namespace StudyService.Models.Dtos
{
    public class StudyingCourseDto
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string InitiatorFullName { get; set; }
    }
}
