using FlightManagment.BlazorServerUI.Services.Authentification;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.UserDTOs;
using System.Text;
using System.Text.Json;

namespace FlightManagment.BlazorServerUI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public const string Login = "https://localhost:7068/api/Account/login";

        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> AuthenticateAsync(LoginUserDTO loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
