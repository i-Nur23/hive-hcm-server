using MediatR;
using RecruitmentService.Application.Common.Dtos.Responses;

namespace RecruitmentService.Application.RequestHandlers.Responses.Commands.AddResponse
{
    public class AddResponseCommand : IRequest<Unit>
    {
        public ResponseCreateDto Response { get; set; }
    }
}
