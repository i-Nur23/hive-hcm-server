using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruitmentService.Application.Common.Vms.Vacancies;
using RecruitmentService.Application.RequestHandlers.Vacancies.Commands.CreateVacancy;
using RecruitmentService.Application.RequestHandlers.Vacancies.Commands.DeleteVacancy;
using RecruitmentService.Application.RequestHandlers.Vacancies.Commands.UpdateVacancy;
using RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetAllVacancies;
using RecruitmentService.Application.RequestHandlers.Vacancies.Queries.GetLeadVacancies;

namespace RecruitmentService.Web.Controllers
{
    [Route("api/vacancies")]
    public class VacanciesController : BaseController
    {
        [HttpGet("all")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> GetAllVacanciesAsync(
            CancellationToken cancellationToken)
        {
            var query = new GetAllVacanciesQuery
            {
                HrId = UserId
            };

            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("leading")]
        public async Task<IActionResult> GetVacanciesForLeadAsync(
            CancellationToken cancellationToken)
        {
            var query = new GetLeadVacanciesQuery
            {
                LeadId = UserId
            };

            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost("new")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> CreateVacancyAsync(
            [FromBody] VacancyVM vacancy,
            CancellationToken cancellationToken)
        {
            var command = new CreateVacancyCommand
            {
                Vacancy = vacancy,
            };

            command.Vacancy.HrId = UserId;

            await Mediator.Send(command, cancellationToken);    

            return Ok();
        }

        [HttpPost("edit")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> UpdateVacancyAsync(
            [FromBody] VacancyVM vacancy,
            CancellationToken cancellationToken)
        {
            var command = new UpdateVacancyCommand
            {
                Vacancy = vacancy,
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("delete")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> DeleteVacancyAsync(
            Guid vacancyId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteVacancyCommand
            {
                VacancyId = vacancyId,
            };

            await Mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
