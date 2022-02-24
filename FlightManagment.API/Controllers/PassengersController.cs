using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.PassengerDTOs;
using FlightManagment.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FlightManagment.API.Controllers
{
    /// <summary>
    /// Endpoint for intraction with Passenger related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IPassengerRepository _passengersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PassengersController(IPassengerRepository passengersRepository, IMapper mapper, ILogger logger)
        {
            _passengersRepository = passengersRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        /// <summary>
        /// Retrives the list of all Passengers
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
                var passengerList = await _passengersRepository.GetAllAsync();
                var passengerListDto = _mapper.Map<List<PassengerBaseDTO>>(passengerList);
                return StatusCode(200, passengerListDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all passengers");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Retrives the list of all Passengers with their Airports
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllWithFlights")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllWithFlights()
        {
            var location = GetControllerActionNames();

            try
            {
                var passengerList = await _passengersRepository.GetAllWithFlights();
                var passengerDetails = _mapper.Map<List<PassengerBaseDTO>>(passengerList);
                return StatusCode(200, passengerDetails);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all passengers");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Retrives the list of all Passengers with their Airports
        /// <paramref name="flightId"/>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCheckedInForFlight/{flightId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCheckedInForFlight(int flightId)
        {
            var location = GetControllerActionNames();

            try
            {
                if (flightId < 1)
                    return BadRequest();

                var passengerList = await _passengersRepository.GetCheckedInForFlight(flightId);
                var passengerDetailsList = _mapper.Map<List<PassengerBaseDTO>>(passengerList);
                return StatusCode(200, passengerDetailsList);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all passengers");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Get a single Passenger by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSinglePassenger/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSingle(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (await _passengersRepository.Exists(id) is false)
                    return StatusCode(404);
                
                var passenger = await _passengersRepository.GetAsync(id);
                var passengerDto = _mapper.Map<PassengerBaseDTO>(passenger);

                return StatusCode(200, passengerDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve Passenger with Id: {id}.");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        
        /// <summary>
        /// Add a single Passenger
        /// </summary>
        /// <param name="passengerDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPassenger")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddPassenger([FromBody]PassengerBaseDTO passengerDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (passengerDto is null)
                    return StatusCode(400);

                if (!ModelState.IsValid)
                    return StatusCode(400, ModelState);

                var passenger = _mapper.Map<Passenger>(passengerDto);
                await _passengersRepository.AddAsync(passenger);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to add Passenger.");
                return InternalError($"{location}: Creation failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Updates an Passenger
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passengerDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdatePassenger/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePassenger(int id, [FromBody] PassengerBaseDTO passengerDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1 || passengerDto is null || passengerDto.Id != id)
                {
                    _logger.Warning($"{location}: Update failed with bad data - id: {id}.");
                    return StatusCode(400);
                }

                // Cannot be used, because Exists uses Tracking which gives Exception, and FindAsync does not support AsNoTracking.
                //if (await _PassengerRepository.Exists(id) is false)
                //{
                //    _logger.Warning($"{location}: Failed to retrieve recored with id: {id}.");
                //    return StatusCode(404);
                //}

                if (!ModelState.IsValid)
                {
                    _logger.Warning($"{location}: Data was incomplete.");
                    return StatusCode(400, ModelState);
                }

                var passenger = _mapper.Map<Passenger>(passengerDto);
                await _passengersRepository.UpdateAsync(passenger);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the Passenger with id - {id}.");
                return InternalError($"{location}: Update failed. {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a single Passenger
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletePassenger/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1)
                    return StatusCode(400);

                if (await _passengersRepository.Exists(id) is false)
                    return StatusCode(404);

                await _passengersRepository.DeleteAsync(id);

                return StatusCode(204);

            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the Passenger with id - {id}.");
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
