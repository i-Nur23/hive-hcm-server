﻿namespace RecruitmentService.Domain.Entities
{
    public class Vacancy
    {
        public Guid Id { get; set; }

        public string Position { get; set; }

        public int SalaryFrom { get; set; }

        public int SalaryTo { get; set; }

        public int ExpirienceYearsFrom { get; set; }

        public int ExpirienceYearsTo { get; set; }

        public string About { get; set; }

        public Guid DivisionId { get; set; }

        public Guid HrId { get; set; }

        public Division Division { get; set; }

        public List<Response> Responses { get; set; }

        public ICollection<Requirement> Requirements { get; set; }

        public ICollection<Offer> Offers { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}