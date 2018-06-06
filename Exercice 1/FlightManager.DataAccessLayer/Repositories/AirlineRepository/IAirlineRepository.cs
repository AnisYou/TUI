using FlightManager.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightManager.DataAccessLayer.Repositories
{
    public interface IAirlineRepository
    {
        IQueryable<Airline> GetAllAirlinesCompanies();
        Airline GetAirlineById(int id);
    }
}
