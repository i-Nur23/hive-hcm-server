using Core.Exceptions;
using EmployeeService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace EmployeeService.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class BaseController : ControllerBase
    {
        protected Guid UserId
        {
            get
            {
                return Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid value)
                    ? value
                    : throw new ForbiddenException();
            }
        } 
    }
}
