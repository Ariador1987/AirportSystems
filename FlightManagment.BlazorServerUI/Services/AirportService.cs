using FlightManagment.Domain.Models;
using FlightManagment.Configurations;
using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using System.Text.Json;
using System.Text;

namespace FlightManagment.BlazorServerUI.Services
{
    public class AirportService
    {
        public const string GetAllPathExtension = "Airports/GetAll";
        public const string GetAllByConstructionDate = "Airports/GetAllByConstructionDate";
        //public const string AddAirport = "Airports/AddAirport";
        public const string AddAirport = "https://localhost:7068/api/Airports/AddAirport";

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

        public async Task AddAirportAsync(AirportCreateDTO airportDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, AddAirport);
            request.Content = new StringContent(JsonSerializer.Serialize(airportDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }
    }
}
