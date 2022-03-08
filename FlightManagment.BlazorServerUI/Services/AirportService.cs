using FlightManagment.Domain.Models;
using FlightManagment.Configurations;
using FlightManagment.Domain.Models.DTOs.AirportDTOs;
using System.Text.Json;
using System.Text;
using AutoMapper;
using Blazored.LocalStorage;

namespace FlightManagment.BlazorServerUI.Services
{
    public class AirportService
    {
        public const string GetAllPathExtension = "Airports/GetAll";
        public const string GetAllByConstructionDate = "Airports/GetAllByConstructionDate";
        public const string GetById = "https://localhost:7068/api/Airports/GetSingleAirport/";
        //public const string AddAirport = "Airports/AddAirport";
        public const string AddAirport = "https://localhost:7068/api/Airports/AddAirport";
        public const string UpdateAirport = "https://localhost:7068/api/Airports/UpdateAirport/";
        public const string DeleteAirport = "https://localhost:7068/api/Airports/DeleteAirport/";


        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public AirportService(HttpClient httpClient, 
            IMapper mapper
            )
        {
            _httpClient = httpClient;
            _mapper = mapper;
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

        public async Task UpdateAirportAsync(AirportUpdateDTO airportDto, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, UpdateAirport + id);
            request.Content = new StringContent(JsonSerializer.Serialize(airportDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task<AirportUpdateDTO> GetAirportByIdForUpdate(int id)
        {
            var airportBaseDto =  await _httpClient.GetFromJsonAsync<AirportBaseDTO>(GetById + id);
            var airportUpdateDto = _mapper.Map<AirportUpdateDTO>(airportBaseDto);
            return airportUpdateDto;
        }

        public async Task DeleteAirportAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, DeleteAirport + id);
            await _httpClient.SendAsync(request);
        }
    }
}
