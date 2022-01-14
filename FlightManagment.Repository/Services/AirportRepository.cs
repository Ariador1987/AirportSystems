﻿using FlightManagment.DAL;
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
    public class AirportRepository : GenericRepository<Airport>, IAirportRepository
    {
        private readonly ApplicationDbContext _context;

        public AirportRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Airport>> GetAllByConstructionDate()
        {
            return await _context.Airports
                .OrderByDescending(x => x.ConstructionDate)
                .ToListAsync();
        }

        //public async Task<bool> UpdateCountriesWithAirports()
        //{
        //    int updatedCount = 0;
        //    var airports = _context.Airports.ToList();
        //    var countries = _context.Countries.ToList();

        //    foreach (var airport in airports)
        //    {
        //        foreach (var country in countries)
        //        {
        //            if (airport.CountryId == country.Id)
        //            {
        //                country.Airports.Add(airport);
        //                updatedCount++;
        //                await _context.SaveChangesAsync();
        //            }
        //        }
        //    }
        //    return updatedCount > 0;
        //}
    }
}