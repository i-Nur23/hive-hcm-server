using AutoMapper;
using RecruitmentService.Application.Common.Dtos.Jobs;
using RecruitmentService.Application.Common.Mappings;
using RecruitmentService.Domain.Entities;
using RecruitmentService.Domain.Enums;

namespace RecruitmentService.Application.Common.Vms.Responses
{
    public class ResponseVM : IMapWith<Response>
    {
        public Guid ResponseId { get; set; }

        public Guid CandidateId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public string About { get; set; }

        public string? Employment { get; set; }

        public string? Schedule { get; set; }

        public ResponseStatus Status { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string TextStatus { get; set; }

        public IEnumerable<JobDto> Jobs { get; set; }

        public int SummaryExpirience => Jobs.Sum(j => j.Expirience);

        public int Years => SummaryExpirience / 12;

        public int Months => SummaryExpirience % 12;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Response, ResponseVM>()
                .ForMember(
                    opt => opt.ResponseId,
                    dest => dest.MapFrom(src => src.Id))
                .ForMember(
                    opt => opt.Name,
                    dest => dest.MapFrom(src => src.Candidate.Name))
                .ForMember(
                    opt => opt.Surname,
                    dest => dest.MapFrom(src => src.Candidate.Surname))
                .ForMember(
                    opt => opt.BirthDate,
                    dest => dest.MapFrom(src => src.Candidate.BirthDate))
                .ForMember(
                    opt => opt.About,
                    dest => dest.MapFrom(src => src.Candidate.About))
                .ForMember(
                    opt => opt.Employment,
                    dest => dest.MapFrom(src => src.Candidate.Employment))
                .ForMember(
                    opt => opt.Age,
                    dest => dest.MapFrom(src => src.Candidate.Age))
                .ForMember(
                    opt => opt.Schedule,
                    dest => dest.MapFrom(src => src.Candidate.Schedule))
                .ForMember(
                    opt => opt.Jobs,
                    dest => dest.MapFrom(src => src.Candidate.Jobs));
        }
    }
}
