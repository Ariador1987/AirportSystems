using FlightManagment.Configurations;
using FlightManagment.Domain.Models;

namespace FlightManagment.BlazorServerUI.Services
{
    public class CountryService
    {
        public const string GetAllPathExtension = "Countries/GetAll";

        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _httpClient.GetFromJsonAsync<List<Country>>(Path.Combine(StaticDetails.ApiBaseUrl, GetAllPathExtension));
        }
    }
}
