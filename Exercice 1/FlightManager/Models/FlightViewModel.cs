using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        [Display(Name ="Flight Code")]
        [Required]
        public string Number { get; set; }
        [Display(Name = "Journey duration")]
        public double FlightTime { get; set; }
        [Display(Name = "Departure")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Departure { get; set; }
        [Display(Name = "Arrival")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Arrival { get; set; }
        [Display(Name = "Operated by")]
        public int AirlineId { get; set; }
        public virtual AirlineViewModel FlightAirline { get; set; }
        [Display(Name ="Departure airport")]
        public int DepartureAirportId { get; set; }
        [Display(Name = "Destination airport")]
        public int ArrivalAirportId { get; set; }
        public AirportViewModel From { get; set; }
        public AirportViewModel To { get; set; }
        [Display(Name = "Distance")]
        public double FlightDistance { get; set; }
        [Display(Name = "Fuel Consumption")]
        public double FuelConsumption { get; set; }
        public IEnumerable<AirportViewModel> AllAirports { get; set; }
        public IEnumerable<AirlineViewModel> AllAirlineCompanies { get; set; }

    }
}
