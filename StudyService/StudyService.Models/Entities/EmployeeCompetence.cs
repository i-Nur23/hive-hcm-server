using StudyService.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyService.Models.Entities
{
    public class EmployeeCompetence
    {
        public Guid EmployeeId { get; set; }

        public Guid CompetenceId { get; set; }

        public CompetenceLevel Level { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("CompetenceId")]
        public Competence Competence { get; set; }
    }
}
