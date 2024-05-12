using MoodService.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoodService.Domain.Entities
{
    public class Assessment
    {
        public Guid Id { get; set; }

        public GradeType Energy { get; set; }

        public GradeType Tranquility { get; set; }

        public GradeType Happiness { get; set; }

        public GradeType Communications { get; set; }

        public GradeType TimeManagement { get; set; }

        public string? Note { get; set; }

        public DateTime RatedAt { get; set; }

        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
