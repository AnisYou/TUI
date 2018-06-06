using FlightManager.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightManager.DataAccessLayer.Repositories
{
    public interface IAirportRepository
    {
        IQueryable<Airport> GetAllAirports();
        Airport GetAirportById(int id);
        IQueryable<Airport> GetAirportsByPrefix(string prefix);
    }
}
