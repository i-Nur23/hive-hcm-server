using AutoMapper;
using MoodService.Application.Interfaces;

namespace MoodService.Application.Common
{
    public class BaseRequestHandler
    {
        protected readonly IApplicationDbContext _dbContext;
        protected readonly IMapper _mapper;

        public BaseRequestHandler(
            IApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
