namespace RecruitmentService.Application.Common.Vms.Vacancies
{
    public class VacanciesVm
    {
        public IEnumerable<VacancyVM> Vacancies { get; set; }

        public int TotalCount { get; set; }
    }
}
