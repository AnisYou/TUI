using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightManager.DataAccessLayer.Entities;

namespace FlightManager.DataAccessLayer.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private FlightManagerDbContext context;

        public AirportRepository(FlightManagerDbContext context)
        {
            this.context = context;
        }


        public Airport GetAirportById(int id)
        {
            try
            {
                return context.Airports.FirstOrDefault(a => a.AirportId == id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<Airport> GetAirportsByPrefix(string prefix)
        {
            try
            {
                return context.Airports.Where(a => a.Name.StartsWith(prefix) || a.Code.StartsWith(prefix));

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<Airport> GetAllAirports()
        {
            try
            {
                return context.Airports;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
