using StudyService.Models.Entities;

namespace StudyService.Application.Interfaces
{
    public interface ICoursesService
    {
        Task<List<Course>> GetStudyingAsync(
            Guid id);

        Task<List<Course>> GetAdminAsync(
            Guid id);

        Task AddAsync(
            Guid iserId,
            string name,
            DateTime start,
            DateTime end,
            IEnumerable<Guid> studentIds);

        Task UpdateAsync(
            Guid courseId,
            string name,
            DateTime start,
            DateTime end, 
            IEnumerable<Guid> studentIds);
    }
}
