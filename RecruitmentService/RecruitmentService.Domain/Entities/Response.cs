using RecruitmentService.Domain.Common.Attributes;
using RecruitmentService.Domain.Common.Extensions;
using RecruitmentService.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentService.Domain.Entities
{
    public class Response
    {
        public Guid Id { get; set; }

        public Guid CandidateId { get; set; }

        public Guid VacancyId { get; set; }

        public Candidate Candidate { get; set; }

        public Vacancy Vacancy { get; set; }

        public ResponseStatus Status { get; set; }

        public DateTime UpdatedAt { get; set; }

        [NotMapped]
        public string TextStatus => Status.GetAttributeOfType<NameAttribute>().Name;
    }
}
