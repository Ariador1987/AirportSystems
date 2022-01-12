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
    public class AirporteRepository : GenericRepository<Airport>, IAirportRepository
    {
        private readonly ApplicationDbContext _context;

        public AirporteRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Airport>> GetAllByConstructionDate()
        {
            return await _context.Airports
                .OrderByDescending(x => x.ConstructionDate)
                .ToListAsync();
        }
    }
}
