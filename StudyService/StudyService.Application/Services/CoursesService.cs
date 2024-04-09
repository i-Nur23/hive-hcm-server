using Core.Exceptions;
using StudyService.Application.Interfaces;
using StudyService.Models.Entities;
using StudyService.Persistence;
using StudyService.Persistence.Repositories.Interfaces;

namespace StudyService.Application.Services
{
    internal class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly DatabaseManager _databaseManager;

        public CoursesService(
            ICoursesRepository coursesRepository, 
            IEmployeesRepository employeesRepository,
            DatabaseManager databaseManager)
        {
            _coursesRepository = coursesRepository;
            _employeesRepository = employeesRepository;
            _databaseManager = databaseManager;
        }

        public async Task AddAsync(
            Guid iserId, 
            string name, 
            DateTime start, 
            DateTime end, 
            IEnumerable<Guid> studentIds)
        {
            Guid courseId = Guid.NewGuid();

            Course course = new Course
            {
                Id = courseId,
                InitiatorId = iserId,
                Name = name,
                StartDate = start,
                EndDate = end
            };

            await _databaseManager.BeginTransactionAsync();

            try
            {
                await _coursesRepository.AddAsync(course);

                await _coursesRepository.AddStudentsAsync(
                    courseId,
                    default,
                    studentIds.ToArray());

                await _databaseManager.CommitTransactionAsync();
            }
            catch (Exception)
            {
                await _databaseManager.RollbackTransactionAsync();
                throw new BadRequestException("Ошибка сохранения данных");
            }
        }

        public async Task<List<Course>> GetAdminAsync(Guid id)
        {
            Employee employee = await _employeesRepository.GetAsync(
                e => e.Id.Equals(id),
                isInitiatedCourseIncluded: true);
            
            if (employee is null)
            {
                throw new BadRequestException("Пользователь не найден");
            }

            return employee.IntitiatedCourses.ToList();
        }

        public async Task<List<Course>> GetStudyingAsync(Guid id)
        {
            Employee employee = await _employeesRepository.GetAsync(
                e => e.Id.Equals(id),
                isInitiatedCourseIncluded: true);

            if (employee is null)
            {
                throw new BadRequestException("Пользователь не найден");
            }

            return employee.Courses.ToList();
        }

        public Task UpdateAsync(Guid courseId, string name, DateTime start, DateTime end, IEnumerable<Guid> studentIds)
        {
            throw new NotImplementedException();
        }
    }
}
