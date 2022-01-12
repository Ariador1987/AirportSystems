using FlightManagment.Domain.Models;
using FlightManagment.Configurations;

namespace FlightManagment.BlazorServerUI.Services
{
    public class AirportService
    {
        public const string GetAllPathExtension = "Airports/GetAll";
        public const string GetAllByConstructionDate = "Airports/GetAllByConstructionDate";
        //public const string FullUrl = "https://localhost:7068/api/Airports/GetAll";

        private readonly HttpClient _httpClient;

        public AirportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<Airport>> GetAirports()
        {
            return await _httpClient.GetFromJsonAsync<List<Airport>>(Path.Combine(StaticDetails.ApiBaseUrl, GetAllPathExtension));
        }

        public async Task<List<Airport>> GetAirportsByConstructionDate()
        {
            return await _httpClient.GetFromJsonAsync<List<Airport>>(Path.Combine(StaticDetails.ApiBaseUrl, GetAllByConstructionDate));
        }
    }
}
