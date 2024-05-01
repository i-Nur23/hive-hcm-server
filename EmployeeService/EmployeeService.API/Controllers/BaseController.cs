using Core.Exceptions;
using EmployeeService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace EmployeeService.API.Controllers
{
    [ApiController]
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

        protected Guid CompanyId
        {
            get
            {
                return Guid.TryParse(User.FindFirst("CompanyId")?.Value, out Guid id)
                    ? id
                    : new Guid();
            }
        }
    }
}
