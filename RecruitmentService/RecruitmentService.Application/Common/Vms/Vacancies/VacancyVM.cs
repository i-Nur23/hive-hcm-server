using AutoMapper;
using RecruitmentService.Application.Common.Mappings;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Common.Vms.Vacancies
{
    public class VacancyVM : IMapWith<Vacancy>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vacancy, VacancyVM>().ReverseMap();
        }
    }
}
