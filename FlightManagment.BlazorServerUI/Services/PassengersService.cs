using AutoMapper;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.PassengerDTOs;
using System.Text;
using System.Text.Json;

namespace FlightManagment.BlazorServerUI.Services
{
    public class PassengersService
    {

        public const string GetAll = "https://localhost:7068/api/Passengers/GetAll";
        public const string GetNonCheckedIn = "https://localhost:7068/api/Passengers/GetNonCheckedInForFlight/";
        public const string GetPassenger = "https://localhost:7068/api/Passengers/GetSinglePassenger/";
        public const string AddPassenger = "https://localhost:7068/api/Passengers/AddPassenger/";
        public const string UpdatePassenger = "https://localhost:7068/api/Passengers/UpdatePassenger/";
        public const string DeletePassenger = "https://localhost:7068/api/Airports/DeletePassenger/";

        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public PassengersService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<Passenger>> GetPassengersWithFlights()
        {
            return await _httpClient.GetFromJsonAsync<List<Passenger>>(GetAll);
        }

        public async Task<List<Passenger>> GetNonCheckedInPassengers()
        {
            return await _httpClient.GetFromJsonAsync<List<Passenger>>(GetNonCheckedIn);
        }

        public async Task AddPassengerAsync(PassengerBaseDTO passengerDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, AddPassenger);
            request.Content = new StringContent(JsonSerializer.Serialize(passengerDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task UpdatePassengerAsync(PassengerBaseDTO passengerDto, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, UpdatePassenger + id);
            request.Content = new StringContent(JsonSerializer.Serialize(passengerDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        // use for get single and for update
        public async Task<PassengerBaseDTO> GetPassengerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PassengerBaseDTO>(GetPassenger + id);
        }

        public async Task DeletePassengerAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, DeletePassenger + id);
            await _httpClient.SendAsync(request);
        }
    }
}
