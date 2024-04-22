using AutoMapper;
using RecruitmentService.Application.Common.Mappings;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Common.Dtos.Responses
{
    public class ResponseCreateDto : IMapWith<Response>
    {
        public Guid CandidateId { get; set; }

        public Guid VacancyId { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<ResponseCreateDto, Response>();
        }
    }
}
