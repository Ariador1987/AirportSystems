using FlightManagment.Domain.Models.DTOs.UserDTOs;

namespace FlightManagment.BlazorServerUI.Services.Authentification
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDTO loginDto);
        
    }

    
}
