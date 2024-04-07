using Microsoft.EntityFrameworkCore;
using StudyService.Models.Entities;
using StudyService.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace StudyService.Persistence.Repositories
{
    internal class CoursesRepository : ICoursesRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public CoursesRepository(
            IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(
            Course course, 
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Courses.AddAsync(course, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddStudentsAsync(
            Guid courseId, 
            CancellationToken cancellationToken, 
            params Guid[] employeeIds)
        {
            _dbContext.EmployeeCourses.AddRangeAsync(employeeIds.Select(id => new EmployeeCourse
            {
                CourseId = courseId,
                EmployeeId = id
            }), 
            cancellationToken);

            _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Course>> GetAllAsync(
            Expression<Func<Course, bool>> predicate = null, 
            bool isIncludeStudents = false, 
            bool isIncludeIntitiator = false, 
            CancellationToken cancellationToken = default)
        {
            IQueryable<Course> query = _dbContext.Courses;

            if (isIncludeStudents)
            {
                query = query.Include(c => c.Employees);
            }

            if (isIncludeIntitiator)
            {
                query = query.Include(c => c.Initiator);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate); 
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Course> GetAsync(
            Expression<Func<Course, bool>> predicate = null, 
            bool isIncludeStudents = false, 
            bool isIncludeIntitiator = false, 
            CancellationToken cancellationToken = default)
        {
            if (predicate is null)
            {
                return null;
            }

            IQueryable<Course> query = _dbContext.Courses;

            if (isIncludeStudents)
            {
                query = query.Include(c => c.Employees);
            }

            if (isIncludeIntitiator)
            {
                query = query.Include(c => c.Initiator);
            }

            return await query
                .Where(predicate)
                .ToListAsync(cancellationToken);
        }
    }
}
