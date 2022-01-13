using FlightManagment.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagment.API.Controllers
{
    /// <summary>
    /// Endpoint for interaction with country related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        public readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Gets a list of all countriees
        /// </summary>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryRepository.GetAllAsync();
            return StatusCode(200, countries);
           
        }

        [HttpGet]
        [Route("GetAllWithCountries")]
        public async Task<IActionResult> GetAllWithCountries() 
        {
            var countries = await _countryRepository.GetAllWithAirports();
            return StatusCode(200, countries);
        }
    }
}
