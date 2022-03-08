using AutoMapper;
using FlightManagment.Configurations;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.FlightDTOs;
using System.Text;
using System.Text.Json;

namespace FlightManagment.BlazorServerUI.Services
{
    public class FlightService
    {
        public const string GetAllPathExtension = "Flights/GetAll";
        public const string GetAllWithDetails = "https://localhost:7068/api/Flights/GetAllWithDetails/";
        public const string GetById = "https://localhost:7068/api/Flights/GetSingleFlight/";
        public const string AddFlight = "https://localhost:7068/api/Flights/AddFlight";
        public const string UpdateFlight = "https://localhost:7068/api/Flights/UpdateFlight/";
        public const string DeleteFlight = "https://localhost:7068/api/Flights/DeleteFlight/";

        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public FlightService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        //public async Task<List<Flight>> GetFlights()
        //{
        //    return await _httpClient.GetFromJsonAsync<List<Flight>>(Path.Combine(StaticDetails.ApiBaseUrl, GetAllPathExtension));
        //}

        public async Task<List<Flight>> GetFlightsWithDetails()
        {
            return await _httpClient.GetFromJsonAsync<List<Flight>>(GetAllWithDetails);
        }
        public async Task AddFlightAsync(FlightCreateDTO flightDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, AddFlight);
            request.Content = new StringContent(JsonSerializer.Serialize(flightDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task UpdateFlightAsync(FlightUpdateDTO flightDto, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, UpdateFlight + id);
            request.Content = new StringContent(JsonSerializer.Serialize(flightDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task<FlightUpdateDTO> GetFlightByIdForUpdate(int id)
        {
            var flightBaseDto = await _httpClient.GetFromJsonAsync<FlightBaseDTO>(GetById + id);
            var flightUpdateDto = _mapper.Map<FlightUpdateDTO>(flightBaseDto);
            return flightUpdateDto;
        }

        public async Task DeleteFlightAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, DeleteFlight + id);
            await _httpClient.SendAsync(request);
        }
    }
}
