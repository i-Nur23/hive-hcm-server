using EmployeeService.Application.Interfaces;
using EmployeeService.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.API.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(
            ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            List<Country> countries = await _countriesService.GetAllAsync();

            return Ok(countries);
        }
    }
}
