using StudyService.Models.Dtos;
using StudyService.Models.Entities;

namespace StudyService.Application.Interfaces
{
    public interface ICoursesService
    {
        Task<List<StudyingCourseDto>> GetStudyingAsync(
            Guid id);

        Task<List<AdminCourseDto>> GetAdminAsync(
            Guid id);

        Task AddAsync(
            Guid iserId,
            string name,
            DateTime start,
            DateTime end,
            IEnumerable<Guid> studentIds);

        Task UpdateAsync(
            Guid courseId,
            Guid initiatorId,
            string name,
            DateTime start,
            DateTime end, 
            IEnumerable<Guid> studentIds);

        Task DeleteAsync(Guid courseId);
    }
}
