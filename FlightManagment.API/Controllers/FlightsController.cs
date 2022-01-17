using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.FlightDTOs;
using FlightManagment.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FlightManagment.API.Controllers
{
    /// <summary>
    /// Endpoint for intraction with Flight related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public FlightsController(IFlightRepository flightRepository, IMapper mapper, ILogger logger)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        /// <summary>
        /// Retrives the list of all Flights
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
                var flightList = await _flightRepository.GetAllAsync();
                var flightListDto = _mapper.Map<List<FlightBaseDTO>>(flightList);
                return StatusCode(200, flightListDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all Flights");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Retrives the list of all Flights
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllWithDetails")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllWithDetails()
        {
            var location = GetControllerActionNames();

            try
            {
                var flightList = await _flightRepository.GetFlightsWithDetails();
                var flightListDto = _mapper.Map<List<FlightDetailsDTO>>(flightList);
                return StatusCode(200, flightList);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all Flights");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Get a single Flight by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSingleFlight/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSingle(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (await _flightRepository.Exists(id) is false)
                    return StatusCode(404);
                
                var flight = await _flightRepository.GetAsync(id);
                var flightDto = _mapper.Map<FlightBaseDTO>(flight);

                return StatusCode(200, flightDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve flight with Id: {id}.");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }


        /// <summary>
        /// Add a single Flight
        /// </summary>
        /// <param name="flightDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFlight")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddFlight([FromBody]FlightCreateDTO flightDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (flightDto is null)
                    return StatusCode(400);

                if (!ModelState.IsValid)
                    return StatusCode(400, ModelState);

                var flight = _mapper.Map<Flight>(flightDto);
                await _flightRepository.AddAsync(flight);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to add flight.");
                return InternalError($"{location}: Creation failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Updates an Flight
        /// </summary>
        /// <param name="id"></param>
        /// <param name="flightDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateFlight/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightUpdateDTO flightDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1 || flightDto is null || flightDto.Id != id)
                {
                    _logger.Warning($"{location}: Update failed with bad data - id: {id}.");
                    return StatusCode(400);
                }

                // Cannot be used, because Exists uses Tracking which gives Exception, and FindAsync does not support AsNoTracking.
                //if (await _flightRepository.Exists(id) is false)
                //{
                //    _logger.Warning($"{location}: Failed to retrieve recored with id: {id}.");
                //    return StatusCode(404);
                //}

                if (!ModelState.IsValid)
                {
                    _logger.Warning($"{location}: Data was incomplete.");
                    return StatusCode(400, ModelState);
                }

                var flight = _mapper.Map<Flight>(flightDto);
                await _flightRepository.UpdateAsync(flight);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the flight with id - {id}.");
                return InternalError($"{location}: Update failed. {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a single Flight
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteFlight/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1)
                    return StatusCode(400);

                if (await _flightRepository.Exists(id) is false)
                    return StatusCode(404);

                await _flightRepository.DeleteAsync(id);

                return StatusCode(204);

            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the flight with id - {id}.");
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
