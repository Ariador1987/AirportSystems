using FlightManagment.Configurations;
using FlightManagment.Domain.Models;
using FlightManagment.Domain.Models.DTOs.CountryDTO;
using FlightManagment.Domain.Models.DTOs.CountryDTOs;
using System.Text;
using System.Text.Json;
using AutoMapper;


namespace FlightManagment.BlazorServerUI.Services
{
    public class CountryService
    {
        public const string GetAllPathExtension = "Countries/GetAll";
        public const string GetById = "https://localhost:7068/api/Countries/GetSingleCountry/";
        public const string AddCountry = "https://localhost:7068/api/Countries/AddCountry";
        public const string UpdateCountry = "https://localhost:7068/api/Countries/UpdateCountry/";
        public const string DeleteCountry = "https://localhost:7068/api/Countries/DeleteCountry/";


        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public CountryService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _httpClient.GetFromJsonAsync<List<Country>>(Path.Combine(StaticDetails.ApiBaseUrl, GetAllPathExtension));
        }
        public async Task AddCountryAsync(CountryBaseDTO countryDto)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, AddCountry);
            request.Content = new StringContent(JsonSerializer.Serialize(countryDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task UpdateCountryAsync(CountryUpdateDTO countryDto, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, UpdateCountry + id);
            request.Content = new StringContent(JsonSerializer.Serialize(countryDto), Encoding.UTF8, "application/json");
            await _httpClient.SendAsync(request);
        }

        public async Task<CountryUpdateDTO> GetCountryByIdForUpdate(int id)
        {
            var countryBaseDto = await _httpClient.GetFromJsonAsync<CountryBaseDTO>(GetById + id);
            var countryUpdateDto = _mapper.Map<CountryUpdateDTO>(countryBaseDto);
            return countryUpdateDto;
        }

        public async Task DeleteCountryAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, DeleteCountry + id);
            await _httpClient.SendAsync(request);
        }
    }
}
