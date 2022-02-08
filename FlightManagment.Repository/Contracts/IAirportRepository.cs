using FlightManagment.Domain.Models;

namespace FlightManagment.Repository.Contracts
{
    public interface IAirportRepository : IGenericRepository<Airport>
    {
        Task<List<Airport>> GetAllByConstructionDate();

        Task<List<Airport>> GetAllWithCountries();

    }
}
