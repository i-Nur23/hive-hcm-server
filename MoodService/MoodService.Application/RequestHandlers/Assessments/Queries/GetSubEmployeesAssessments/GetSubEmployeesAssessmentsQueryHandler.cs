using AutoMapper;
using Core.Dtos.MessageBroker;
using Core.Events;
using Core.Exceptions;
using Core.Responses;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MoodService.Application.Common;
using MoodService.Application.Interfaces;
using MoodService.Domain.Entities;

namespace MoodService.Application.RequestHandlers.Assessments.Queries.GetSubEmployeesAssessments
{
    public class GetSubEmployeesAssessmentsQueryHandler :
        BaseRequestHandler,
        IRequestHandler<GetSubEmployeesAssessmentsQuery, StatisticsVM>
    {
        private readonly IRequestClient<GetLeadingEmployeesEvent> _getLeadingEmployeesClient;

        public GetSubEmployeesAssessmentsQueryHandler(
            IApplicationDbContext dbContext, 
            IMapper mapper,
            IRequestClient<GetLeadingEmployeesEvent> getLeadingEmployeesClient) : base(dbContext, mapper)
        {
            _getLeadingEmployeesClient = getLeadingEmployeesClient;
        }

        public async Task<StatisticsVM> Handle(
            GetSubEmployeesAssessmentsQuery request, 
            CancellationToken cancellationToken)
        {
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>(); 

            try
            {
                var response = await _getLeadingEmployeesClient.GetResponse<GetLeadingEmployeesResponse>(new GetLeadingEmployeesEvent
                {
                    LeadId = request.LeadId,
                });

                employeeDtos = response.Message.Employees.ToList();
            }
            catch (RequestTimeoutException)
            {
                throw new BadRequestException("Превышено время ожидания запроса");
            }

            StatisticsVM statisticsVM = new StatisticsVM
            {
                IsEmpty = true,
            };

            if (employeeDtos.Count() is 0)
            {
                return statisticsVM;
            }

            IEnumerable<Guid> employeeIds = employeeDtos.Select(emp => emp.Id); 

            DateTime now = DateTime.UtcNow;

            DateTime startDate = now.AddDays(-(int)now.DayOfWeek - 13).Date;
            DateTime endDate = now.AddDays(-(int)now.DayOfWeek - 6).Date;

            List<Assessment> lastWeekAssessments = await _dbContext.Assessments.
                Where(
                    assessment => employeeIds.Contains(assessment.EmployeeId) &&
                    assessment.RatedAt >= startDate && 
                    assessment.RatedAt < endDate)
                .ToListAsync(cancellationToken);

            if (lastWeekAssessments.Count() is 0)
            {
                return statisticsVM;
            }

            statisticsVM.IsEmpty = false;

            statisticsVM.Notes = lastWeekAssessments
                .Select(assessment => assessment.Note)
                .Where(note => note is not null);

            statisticsVM.AverageEnergy = lastWeekAssessments.Average(a => (int)a.Energy);
            statisticsVM.AverageHappiness = lastWeekAssessments.Average(a => (int)a.Happiness);
            statisticsVM.AverageTranquility = lastWeekAssessments.Average(a => (int)a.Tranquility);
            statisticsVM.AverageTimeManagement = lastWeekAssessments.Average(a => (int)a.TimeManagement);
            statisticsVM.AverageCommunications = lastWeekAssessments.Average(a => (int)a.Communications);

            return statisticsVM;
        }
    }
}
