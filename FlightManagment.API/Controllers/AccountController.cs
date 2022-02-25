using AutoMapper;
using FlightManagment.Configurations;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ILogger = Serilog.ILogger;


namespace FlightManagment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public AccountController(ILogger logger, 
            IMapper mapper,
            UserManager<ApplicationUser> userManager, 
            IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Endpoint for registering application users
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Register([FromBody]RegisterUserDTO userDto)
        {
            var location = GetControllerActionNames();

            try
            {
                _logger.Information($"Registration attempt at: {location}, for: {userDto.Email} with role: {userDto.Role}");

                if (userDto is null || ModelState.IsValid is false)
                    return StatusCode(400, ModelState);

                var user = _mapper.Map<ApplicationUser>(userDto);
                user.UserName = userDto.Email;
                var result = await _userManager.CreateAsync(user, userDto.Password);

                if (result.Succeeded is false)
                {
                    _logger.Warning($"{location}: Semething went wrong while attempting to create user.");

                    foreach (var error in result.Errors)
                    {
                        _logger.Error($"{error.Code} - while attempting to create user. Message - {error.Description}");
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return StatusCode(400, ModelState);
                }

                // expecting all lowercase from Json, and Roles are defined with first letter Uppercase
                await _userManager.AddToRoleAsync(user, CapitalizeString(userDto.Role));
                _logger.Information($"Successfully added: {user.Email} to Role: {userDto.Role}");
                return StatusCode(202);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with registration for user - {userDto.Email}.");
                return InternalError($"{location}: Register failed. {ex.Message} - {ex.InnerException}");
            }
        }

        /// <summary>
        /// Endpoint for logging in application user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(202)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AccountResponse>> Login(LoginUserDTO userDto)
        {
            var location = GetControllerActionNames();

            try
            {
                var user = await _userManager.FindByEmailAsync(userDto.Email);
                bool passwordValid = await _userManager.CheckPasswordAsync(user, userDto.Password);

                if (user is null)
                    return StatusCode(404);

                if (passwordValid is false)
                    return StatusCode(401, userDto);

                var tokenString = await GenerateToken(user);

                var response = new AccountResponse
                {
                    Email = userDto.Email,
                    Token = tokenString,
                    UserId = user.Id
                };

                return StatusCode(202, response);
            }
            catch (Exception ex)
            {
                _logger.Warning($"{location}: Something went wrong with login user - {userDto.Email}.");
                return InternalError($"{location}: Login failed. {ex.Message} - {ex.InnerException}");
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

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                // reminder username is email, same value.
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(StaticDetails.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtSettings:Duration"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string CapitalizeString(string input)
        {
            var copied = input.Trim();
            return new string(char.ToUpper(copied[0]) + copied.Substring(1).ToLower());
        }
        #endregion
    }
}
