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
    public class FlightRepository : GenericRepository<Flight>, IFlightRepository
    {
        private readonly ApplicationDbContext _context;
        public FlightRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetFlightsWithDetails()
        {
            return await _context.Flights
                .Include(x => x.Passengers)
                .Include(x => x.Airport)
                .ThenInclude(airport => airport.Country)
                .ToListAsync();
        }
    }
}
