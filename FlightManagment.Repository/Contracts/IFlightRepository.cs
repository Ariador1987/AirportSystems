using FlightManagment.Domain.Models;

namespace FlightManagment.Repository.Contracts
{
    public interface IFlightRepository : IGenericRepository<Flight>
    {
        Task<List<Flight>> GetFlightsWithDetails();
    }
}
