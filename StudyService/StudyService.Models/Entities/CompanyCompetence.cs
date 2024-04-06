namespace StudyService.Models.Entities
{
    public class CompanyCompetence
    {
        public Guid CompetenceId { get; set; }

        public Guid CompanyId { get; set; }

        public Competence Competence { get; set; }
    }
}
