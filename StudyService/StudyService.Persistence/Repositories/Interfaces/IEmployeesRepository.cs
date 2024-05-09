using StudyService.Models.Entities;
using System.Linq.Expressions;

namespace StudyService.Persistence.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        public Task AddAsync(
            Employee employee,
            CancellationToken cancellationToken = default);

        public Task<Employee> GetAsync(
            Expression<Func<Employee, bool>> condition = null,
            bool isCoursesIncluded = false,
            bool isInitiatedCourseIncluded = false,
            CancellationToken cancellationToken = default);

        public Task<List<Employee>> GetAllAsync(
            Expression<Func<Employee, bool>> condition = null,
            bool isCoursesIncluded = false,
            bool isInitiatedCourseIncluded = false,
            CancellationToken cancellationToken = default);

        public Task UpdateAsync(
            Employee employee,
            CancellationToken cancellationToken = default);

        public Task DeleteAsync(
            Guid employeeId,
            CancellationToken cancellationToken = default);
    }
}
