using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightManager.DataAccessLayer.Entities
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        public string Number { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

        [ForeignKey("DepartureAirportId")]
        public virtual Airport From { get; set; }
        [ForeignKey("ArrivalAirportId")]
        public virtual Airport To { get; set; }

        public int AirlineId { get; set; }

        [ForeignKey("AirlineId")]
        public virtual Airline FlightAirline { get; set; }
    }
}
