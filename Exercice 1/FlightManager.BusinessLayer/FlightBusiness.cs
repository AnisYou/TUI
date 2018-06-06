using GeoCoordinatePortable;
using System;

namespace FlightManager.BusinessLayer
{
    public class FlightBusiness
    {
        private const double TakeOffEffort = 1;
        private const double FuelConsumption = 3.18;
        public static double CalculateDistance(GeoCoordinate positionA, GeoCoordinate positionB)
        {
            if (positionA != null && positionB != null)
                return positionA.GetDistanceTo(positionB) / 1000;
            return 0;
        }
        public static double CalculateFuelConsumption(double distance, double flightTime)
        {
            return ((FuelConsumption * distance) / flightTime) + TakeOffEffort;
        }
    }
}
