using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using FlightManagment.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FlightManagment.API.Controllers
{
    /// <summary>
    /// Endpoint for intraction with Airport related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AirportsController(IAirportRepository airportRepository, IMapper mapper, ILogger logger)
        {
            _airportRepository = airportRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        /// <summary>
        /// Retrives the list of all Airports
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            var location = GetControllerActionNames();

            try
            {
                var airportList = await _airportRepository.GetAllAsync();
                var airportListDto = _mapper.Map<List<AirportBaseDTO>>(airportList);
                return StatusCode(200, airportListDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all airports");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Get a single Airport by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSingleAirport/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSingle(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (await _airportRepository.Exists(id) is false)
                    return StatusCode(404);
                
                var airport = await _airportRepository.GetAsync(id);
                var airportDto = _mapper.Map<AirportBaseDTO>(airport);

                return StatusCode(200, airportDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve airport with Id: {id}.");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// List of Airports sorted by construction date descending
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllByConstructionDate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllByConstructionDate()
        {
            var location = GetControllerActionNames();

            try
            {
                var airportList = await _airportRepository.GetAllByConstructionDate();
                var airportListDto = _mapper.Map<List<AirportBaseDTO>>(airportList);
                return StatusCode(200, airportListDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all airports by construction");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Add a single Airport
        /// </summary>
        /// <param name="airportDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddAirport")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddAirport([FromBody]AirportCreateDTO airportDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (airportDto is null)
                    return StatusCode(400);

                if (!ModelState.IsValid)
                    return StatusCode(400, ModelState);

                var airport = _mapper.Map<Airport>(airportDto);
                await _airportRepository.AddAsync(airport);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to add airport.");
                return InternalError($"{location}: Creation failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Updates an Airport
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airportDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateAirport/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateAirport(int id, [FromBody] AirportUpdateDTO airportDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1 || airportDto is null || airportDto.Id != id)
                {
                    _logger.Warning($"{location}: Update failed with bad data - id: {id}.");
                    return StatusCode(400);
                }

                // Cannot be used, because Exists uses Tracking which gives Exception, and FindAsync does not support AsNoTracking.
                //if (await _airportRepository.Exists(id) is false)
                //{
                //    _logger.Warning($"{location}: Failed to retrieve recored with id: {id}.");
                //    return StatusCode(404);
                //}

                if (!ModelState.IsValid)
                {
                    _logger.Warning($"{location}: Data was incomplete.");
                    return StatusCode(400, ModelState);
                }

                var airport = _mapper.Map<Airport>(airportDto);
                await _airportRepository.UpdateAsync(airport);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the airport with id - {id}.");
                return InternalError($"{location}: Update failed. {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a single Airport
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteAirport/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1)
                    return StatusCode(400);

                if (await _airportRepository.Exists(id) is false)
                    return StatusCode(404);

                await _airportRepository.DeleteAsync(id);

                return StatusCode(204);

            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the airport with id - {id}.");
                return InternalError($"{location}: Update failed. {ex.Message} - {ex.InnerException}");
            }
        }

        #region Privates
        private string GetControllerActionNames()
        {
           var controller = ControllerContext.ActionDescriptor.ControllerName;
           var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller} {action}";
        }
        
        private ObjectResult InternalError(string message)
        {
            _logger.Error(message);
            return StatusCode(500, "Something went wrong please contact the administrator.");
        }
        #endregion

    }
}
