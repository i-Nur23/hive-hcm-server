using AutoMapper;
using RecruitmentService.Application.Common.Mappings;
using RecruitmentService.Domain.Entities;

namespace RecruitmentService.Application.Common.Dtos.Jobs
{
    public class JobDto : IMapWith<Job>
    {
        public int Expirience { get; set; }

        public string CompanyName { get; set; }

        public string Position { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobDto, Job>();
        }
    }
}
