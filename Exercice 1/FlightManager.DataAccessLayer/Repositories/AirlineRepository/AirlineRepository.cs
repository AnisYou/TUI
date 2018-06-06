using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightManager.DataAccessLayer.Entities;

namespace FlightManager.DataAccessLayer.Repositories
{
    public class AirlineRepository : IAirlineRepository
    {
        private FlightManagerDbContext context;

        public AirlineRepository(FlightManagerDbContext context)
        {
            this.context = context;
        }
        public Airline GetAirlineById(int id)
        {
            try
            {
                return context.Airlines.FirstOrDefault(a => a.AirlineId == id);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<Airline> GetAllAirlinesCompanies()
        {
            try
            {
                return context.Airlines;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
