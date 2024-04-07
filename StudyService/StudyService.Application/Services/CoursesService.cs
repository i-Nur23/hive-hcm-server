using StudyService.Application.Interfaces;
using StudyService.Persistence.Repositories.Interfaces;

namespace StudyService.Application.Services
{
    internal class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesService(
            ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
    }
}
