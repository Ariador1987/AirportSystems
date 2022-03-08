using FlightManagment.Domain.Models;

namespace FlightManagment.Repository.Contracts
{
    public interface IPassengerRepository : IGenericRepository<Passenger>
    {
        Task<List<Passenger>> GetAllWithFlights();

        Task<List<Passenger>> GetNonCheckedInForFlight(int id);
    }
}
