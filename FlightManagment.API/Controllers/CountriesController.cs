using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.CountryDTO;
using FlightManagment.Domain.Models.DTOs.CountryDTOs;
using FlightManagment.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FlightManagment.API.Controllers
{
    /// <summary>
    /// Endpoint for intraction with Country related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countriesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper, ILogger logger)
        {
            _countriesRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        /// <summary>
        /// Retrives the list of all Countrys
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
                var countryList = await _countriesRepository.GetAllAsync();
                var countryListDto = _mapper.Map<List<CountryBaseDTO>>(countryList);
                return StatusCode(200, countryListDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all countries");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Retrives the list of all Countrys with their Airports
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllWithAirports")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllWithAirports()
        {
            var location = GetControllerActionNames();

            try
            {
                var countryList = await _countriesRepository.GetAllWithAirports();
                //var countryDetailsDto = _mapper.Map<List<CountryDetailsDTO>>(countryList);
                return StatusCode(200, countryList);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve all countries");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Get a single Country by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSingleCountry/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSingle(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (await _countriesRepository.Exists(id) is false)
                    return StatusCode(404);
                
                var country = await _countriesRepository.GetAsync(id);
                var countryDto = _mapper.Map<CountryBaseDTO>(country);

                return StatusCode(200, countryDto);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to retrieve Country with Id: {id}.");
                return InternalError($"{location}: Retrieval failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        
        /// <summary>
        /// Add a single Country
        /// </summary>
        /// <param name="countryDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCountry")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AddCountry([FromBody]CountryBaseDTO countryDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (countryDto is null)
                    return StatusCode(400);

                if (!ModelState.IsValid)
                    return StatusCode(400, ModelState);

                var country = _mapper.Map<Country>(countryDto);
                await _countriesRepository.AddAsync(country);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Semething went wrong while attempting to add Country.");
                return InternalError($"{location}: Creation failed. {ex.Message} - {ex.InnerException}.");
            }
        }

        /// <summary>
        /// Updates an Country
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCountry/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryUpdateDTO countryDto)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1 || countryDto is null || countryDto.Id != id)
                {
                    _logger.Warning($"{location}: Update failed with bad data - id: {id}.");
                    return StatusCode(400);
                }

                // Cannot be used, because Exists uses Tracking which gives Exception, and FindAsync does not support AsNoTracking.
                //if (await _CountryRepository.Exists(id) is false)
                //{
                //    _logger.Warning($"{location}: Failed to retrieve recored with id: {id}.");
                //    return StatusCode(404);
                //}

                if (!ModelState.IsValid)
                {
                    _logger.Warning($"{location}: Data was incomplete.");
                    return StatusCode(400, ModelState);
                }

                var country = _mapper.Map<Country>(countryDto);
                await _countriesRepository.UpdateAsync(country);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the Country with id - {id}.");
                return InternalError($"{location}: Update failed. {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Deletes a single Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCountry/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var location = GetControllerActionNames();

            try
            {
                if (id < 1)
                    return StatusCode(400);

                if (await _countriesRepository.Exists(id) is false)
                    return StatusCode(404);

                await _countriesRepository.DeleteAsync(id);

                return StatusCode(204);

            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with updating the Country with id - {id}.");
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
