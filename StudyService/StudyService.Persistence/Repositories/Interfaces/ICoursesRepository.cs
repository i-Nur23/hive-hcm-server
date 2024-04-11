using StudyService.Models.Entities;
using System.Linq.Expressions;

namespace StudyService.Persistence.Repositories.Interfaces
{
    public interface ICoursesRepository
    {
        public Task<Course> GetAsync(
            Expression<Func<Course, bool>> predicate = null,
            bool isIncludeStudents = false,
            bool isIncludeIntitiator = false,
            CancellationToken cancellationToken = default);

        public Task<List<Course>> GetAllAsync(
            Expression<Func<Course, bool>> predicate = null,
            bool isIncludeStudents = false,
            bool isIncludeIntitiator = false,
            CancellationToken cancellationToken = default);

        public Task AddAsync(
            Course course,
            CancellationToken cancellationToken = default);

        public Task AddStudentsAsync(
            Guid courseId,
            CancellationToken cancellationToken,
            params Guid[] employeeIds);

        public Task UpdateAsync(
            Course course,
            CancellationToken cancellationToken = default);

        public Task UpdateStudentsAsync(
            Guid courseId,
            CancellationToken cancellationToken,
            params Guid[] employeeIds);

        public Task DeleteAsync(Guid courseId);
    }
}
