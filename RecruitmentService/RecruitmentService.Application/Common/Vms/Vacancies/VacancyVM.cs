using AutoMapper;
using RecruitmentService.Application.Common.Mappings;
using RecruitmentService.Application.Common.Vms.Responses;
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

        public string Requirements { get; set; }

        public string Offers { get; set; }

        public IEnumerable<ResponseVM>? Responses { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vacancy, VacancyVM>()
                .ForMember(
                    dest => dest.Requirements, 
                    opt => opt.MapFrom(src => src.RequirementsDescription))
                .ForMember(
                    dest => dest.Offers, 
                    opt => opt.MapFrom(src => src.OffersDescription));

            profile.CreateMap<VacancyVM, Vacancy>()
                .ForMember(
                    dest => dest.RequirementsDescription,
                    opt => opt.MapFrom(src => src.Requirements))
                .ForMember(
                    dest => dest.OffersDescription,
                    opt => opt.MapFrom(src => src.Offers))
                .ForMember(
                    dist => dist.Responses,
                    opt => opt.Ignore());
        }
    }
}
