using RecruitmentService.Domain.Common.Attributes;

namespace RecruitmentService.Domain.Enums
{
    public enum EmploymentType
    {
        [Name("Полная занятость")]
        Full,

        [Name("Частичная занятость")]
        PartTime,

        [Name("Проектная работа")]
        Project,

        [Name("Волонтерство")]
        Volunteer,

        [Name("Стажировка")]
        Intern
    }
}
