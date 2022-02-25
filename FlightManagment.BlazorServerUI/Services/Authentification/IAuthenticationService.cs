using FlightManagment.Domain.Models.DTOs.UserDTOs;

namespace FlightManagment.BlazorServerUI.Services.Authentification
{
    public interface IAuthenticationService
    {
        public Task<bool> Register(RegisterUserDTO registerDto);

        public Task<bool> Login(LoginUserDTO loginDto);

        public Task Logout();
    }

    
}
