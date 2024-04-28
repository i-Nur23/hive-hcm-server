namespace RecruitmentService.Application.Common.Vms.Vacancies
{
    public class LeadVacanciesVM
    {
        public IEnumerable<LeadVacancyVM> Vacancies { get; set; }

        public int TotalCount { get; set; }
    }
}
