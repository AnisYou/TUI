using AutoMapper;
using FlightManager.BusinessLayer;
using FlightManager.DataAccessLayer.Entities;
using FlightManager.Models;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Helpers
{
    public class MappingHelper : Profile
    {
        public MappingHelper()
        {
            CreateMap<Flight, FlightViewModel>();
            CreateMap<Airline, AirlineViewModel>();
            CreateMap<Airport, AirportViewModel>();
        }
    }
}
