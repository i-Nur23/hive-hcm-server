using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
            await _dbContext.EmployeeCourses.AddRangeAsync(employeeIds.Select(id => new EmployeeCourse
            {
                CourseId = courseId,
                EmployeeId = id
            }), 
            cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
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
            IQueryable<Course> query = _dbContext.Courses;

            if (isIncludeStudents)
            {
                query = query.Include(c => c.Employees);
            }

            if (isIncludeIntitiator)
            {
                query = query.Include(c => c.Initiator);
            }

            if (predicate is null)
            {
                return await query.FirstAsync(cancellationToken);
            }

            return await query.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task UpdateAsync(
            Course course, 
            CancellationToken cancellationToken = default)
        {
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStudentsAsync(
            Guid courseId, 
            CancellationToken cancellationToken, 
            params Guid[] employeeIds)
        {
            List<EmployeeCourse> employeeCourses = _dbContext.EmployeeCourses
                .Where(ec => ec.CourseId.Equals(courseId))
                .ToList(); 

            List<EmployeeCourse> addingEmployeeCourses = new List<EmployeeCourse>();
            List<EmployeeCourse> deletingEmployeeCourses = new List<EmployeeCourse>();

            foreach (var employeeCourse in employeeCourses)
            {
                if (!employeeIds.Any(id => employeeCourse.EmployeeId.Equals(id)))
                {
                    deletingEmployeeCourses.Add(employeeCourse);
                }
            }

            foreach (var id in employeeIds)
            {
                if (!employeeCourses.Any(ec => ec.EmployeeId.Equals(id)))
                {
                    addingEmployeeCourses.Add(new EmployeeCourse
                    {
                        CourseId = courseId,
                        EmployeeId = id
                    });
                }
            }

            await _dbContext.EmployeeCourses.AddRangeAsync(addingEmployeeCourses, cancellationToken);
            _dbContext.EmployeeCourses.RemoveRange(deletingEmployeeCourses);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid courseId)
        {
            string sql = "DELETE FROM Courses WHERE Id = {0}";
            await _dbContext.Database.ExecuteSqlRawAsync(sql, courseId);
        }
    }
}
