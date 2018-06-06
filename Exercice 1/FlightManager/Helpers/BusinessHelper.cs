using FlightManager.BusinessLayer;
using FlightManager.Models;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightManager.Helpers
{
    public class BusinessHelper
    {
        public static IEnumerable<FlightViewModel> CalculateData(IEnumerable<FlightViewModel> flightViewModel)
        {
            return flightViewModel.Select(f =>
            {
                f.FlightDistance = FlightBusiness.CalculateDistance(new GeoCoordinate(f.From.Latitude, f.From.Longitude), new GeoCoordinate(f.To.Latitude, f.To.Longitude));
                f.FlightTime = ((TimeSpan)(f.Arrival - f.Departure)).TotalHours;
                f.FuelConsumption = FlightBusiness.CalculateFuelConsumption(f.FlightDistance, f.FlightTime);
                return f;
            });


        }
    }
}
