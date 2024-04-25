using RecruitmentService.Domain.Common.Attributes;

namespace RecruitmentService.Domain.Enums
{
    public enum ResponseStatus
    {
        /// <summary>
        /// Не обработан
        /// </summary>
        [Name("Ожидает обработки")]
        NotProcessed,

        /// <summary>
        /// Принят
        /// </summary>
        [Name("Принят")]
        Accepted,

        /// <summary>
        /// Отказ
        /// </summary>
        [Name("Отказ")]
        Refuse,

        /// <summary>
        /// Приглашен
        /// </summary>
        [Name("Приглашение")]
        Invitation
    }
}
