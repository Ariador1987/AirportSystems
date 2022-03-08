using FlightManagment.DAL;
using FlightManagment.Domain.Models;
using FlightManagment.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagment.Repository.Services
{
    public class PassengersRepository : GenericRepository<Passenger>, IPassengerRepository
    {
        private readonly ApplicationDbContext _context;

        public PassengersRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Passenger>> GetAllWithFlights()
        {
            return await _context.Passengers
                .Include(x => x.Flight)
                .Where(x => x.FlightId == x.Flight.Id)
                .OrderByDescending(x => x.FlightId)
                .ToListAsync();
        }

        public async Task<List<Passenger>> GetNonCheckedInForFlight(int id)
        {
            return await _context.Passengers
                .Include(x => x.Flight)
                .Where(x => x.FlightId == id && x.isCheckedIn == false)
                .ToListAsync();
        }
    }
}
