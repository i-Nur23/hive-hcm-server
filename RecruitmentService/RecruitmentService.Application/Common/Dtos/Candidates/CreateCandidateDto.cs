using AutoMapper;
using RecruitmentService.Application.Common.Dtos.Jobs;
using RecruitmentService.Application.Common.Mappings;
using RecruitmentService.Application.RequestHandlers.Candidates.Commands.CreateCandidate;
using RecruitmentService.Domain.Entities;
using RecruitmentService.Domain.Enums;

namespace RecruitmentService.Application.Common.Dtos.Candidates
{
    public class CreateCandidateDto : IMapWith<Candidate>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string About { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public ScheduleType ScheduleType { get; set; }

        public List<JobDto> Jobs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCandidateDto, Candidate>()
                .ForMember(x => x.Jobs, opt => opt.Ignore());
        }
    }
}
