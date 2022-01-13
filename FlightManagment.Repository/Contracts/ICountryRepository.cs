using FlightManagment.Domain.Models;

namespace FlightManagment.Repository.Contracts
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<List<Country>> GetAllWithAirports();
    }
}
