using Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RecruitmentService.Web.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

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
