using Core.Dtos.MessageBroker;

namespace Core.Responses
{
    public class GetLeadingEmployeesResponse
    {
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
