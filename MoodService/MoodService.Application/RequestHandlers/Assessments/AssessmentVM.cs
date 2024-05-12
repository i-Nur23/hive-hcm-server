using AutoMapper;
using MoodService.Application.Common.Mappings;
using MoodService.Domain.Entities;
using MoodService.Domain.Enums;

namespace MoodService.Application.RequestHandlers.Assessments
{
    public class AssessmentVM : IMapWith<Assessment>
    {
        public GradeType Energy { get; set; }

        public GradeType Tranquility { get; set; }

        public GradeType Happiness { get; set; }

        public GradeType Communications { get; set; }

        public GradeType TimeManagement { get; set; }

        public string Note { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssessmentVM, Assessment>()
                .ForMember(dest => dest.RatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeId, opt => opt.Ignore());

            profile.CreateMap<Assessment, AssessmentVM>();
        }
    }
}
