namespace RecruitmentService.Domain.Entities
{
    public class Job
    {
        public Guid Id { get; set; }

        public int Expirience { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public Guid CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
