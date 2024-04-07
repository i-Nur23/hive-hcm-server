using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace StudyService.Web.Controllers
{
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
