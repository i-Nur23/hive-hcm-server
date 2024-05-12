using MoodService.Domain.Enums;

namespace MoodService.Application.RequestHandlers.Assessments
{
    public class StatisticsVM
    {
        public double AverageEnergy { get; set; }

        public double AverageTranquility { get; set; }

        public double AverageHappiness { get; set; }

        public double AverageCommunications { get; set; }

        public double AverageTimeManagement { get; set; }

        public IEnumerable<string> Notes { get; set; }

        public bool IsEmpty { get; set; }
    }
}
