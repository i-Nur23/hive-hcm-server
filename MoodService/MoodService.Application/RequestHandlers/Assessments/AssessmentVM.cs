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

        public GradeType Health { get; set; }

        public GradeType Happiness { get; set; }

        public string Note { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssessmentVM, Assessment>();
        }
    }
}
