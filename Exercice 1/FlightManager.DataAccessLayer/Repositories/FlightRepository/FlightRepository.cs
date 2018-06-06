using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightManager.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightManager.DataAccessLayer.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private FlightManagerDbContext context;

        public FlightRepository(FlightManagerDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(Flight flight)
        {
            try
            {
                context.Add(flight);
                await context.SaveChangesAsync();
                return flight.FlightId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Flight flight = await context.Flights.FirstOrDefaultAsync(f => f.FlightId == id);
                if (flight != null)
                {
                    context.Remove(flight);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Flight> GetFlightById(int id)
        {
            try
            {
                return await context.Flights.Include(f => f.FlightAirline)
                .Include(f => f.From)
                .Include(f => f.To).SingleOrDefaultAsync(f => f.FlightId == id);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IQueryable<Flight> GetAllFlights()
        {
            try
            {
                return context.Flights.Include(f => f.FlightAirline)
                .Include(f => f.From)
                .Include(f => f.To).AsQueryable<Flight>();


            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task Update(Flight flight)
        {
            try
            {
                context.Update(flight);
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
