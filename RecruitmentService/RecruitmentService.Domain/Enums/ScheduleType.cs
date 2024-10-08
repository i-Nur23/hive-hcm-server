﻿using RecruitmentService.Domain.Common.Attributes;

namespace RecruitmentService.Domain.Enums
{
    public enum ScheduleType
    {
        [Name("Полный день")]
        Full,

        [Name("Сменный график")]
        Shift,

        [Name("Удаленная работа")]
        Remote,

        [Name("Гибкий график")]
        Flex,

        [Name("Вахтовый метод")]
        Rotational
    }
}
