using RecruitmentService.Domain.Common.Attributes;
using RecruitmentService.Domain.Common.Extensions;
using RecruitmentService.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentService.Domain.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BitrhDate { get; set; }

        public string About { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public ScheduleType ScheduleType { get; set; }

        [NotMapped]
        public string? Employment => EmploymentType.GetAttributeOfType<NameAttribute>()?.Name;

        [NotMapped]
        public string? Schedule => ScheduleType.GetAttributeOfType<NameAttribute>()?.Name;

        [NotMapped]
        public int Expirience => Jobs?.Sum(x => x.Expirience) ?? 0;

        public ICollection<Job> Jobs { get; set; }

        public List<Response> Responses { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
