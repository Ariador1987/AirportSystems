using FlightManagment.Domain.Models;
using FlightManagment.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagment.API.Controllers
{
    /// <summary>
    /// Endpoint for intraction with airport related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;
        
        public AirportsController(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }
        
        /// <summary>
        /// Retrives the list of all airports
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var airportList = await _airportRepository.GetAllAsync();
            return StatusCode(200, airportList);
        }

        /// <summary>
        /// Get a single airport with list of flights
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSingleAirport/{id:int}")]
        public async Task<IActionResult> GetSingleWithDetails(int id)
        {
            var airport = await _airportRepository.GetAsync(id);
            return StatusCode(200, airport);
        }

        /// <summary>
        /// List of airports sorted by construction date descending.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllByConstructionDate")]
        public async Task<IActionResult> GetAllByConstructionDate()
        {
            try
            {
                var airportsByConstruction = await _airportRepository.GetAllByConstructionDate();
                return StatusCode(200, airportsByConstruction);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Add a single airport with list of flights
        /// </summary>
        /// <param name="airport"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAirport")]
        public async Task<IActionResult> AddAirport([FromBody]Airport airport)
        {
            await _airportRepository.AddAsync(airport);
            return StatusCode(201, airport);
        }
    }
}
