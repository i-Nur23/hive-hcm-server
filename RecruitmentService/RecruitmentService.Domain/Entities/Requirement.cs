namespace RecruitmentService.Domain.Entities
{
    public class Requirement
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid VacancyId { get; set; }

        public Vacancy Vacancy { get; set; }
    }
}
