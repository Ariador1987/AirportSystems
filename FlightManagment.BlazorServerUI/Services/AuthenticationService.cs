using Blazored.LocalStorage;
using FlightManagment.BlazorServerUI.Providers;
using FlightManagment.BlazorServerUI.Services.Authentification;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.UserDTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FlightManagment.BlazorServerUI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public const string LoginPath = "https://localhost:7068/api/Account/login";
        public const string RegisterPath = "https://localhost:7068/api/Account/register";

        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(HttpClient httpClient, 
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Register(RegisterUserDTO registerDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, RegisterPath);
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(registerDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

        public async Task<bool> Login(LoginUserDTO loginDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, LoginPath);
            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return false;

            var content = await response.Content.ReadAsStringAsync();
            var accountResponse = JsonConvert.DeserializeObject<AccountResponse>(content);


            // store token
            await _localStorage.SetItemAsync("authToken", accountResponse.Token);

            // change auth state of app
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accountResponse.Token);

            return true;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }
    }
}
