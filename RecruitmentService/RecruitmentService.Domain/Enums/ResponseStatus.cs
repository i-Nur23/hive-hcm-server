using RecruitmentService.Domain.Common.Attributes;

namespace RecruitmentService.Domain.Enums
{
    public enum ResponseStatus
    {
        [Name("Ожидает обработки")]
        NotProcessed, 

        [Name("Принят")]
        Accepted,

        [Name("Отказ")]
        Refuse,

        [Name("Приглашение")]
        Invitation
    }
}
