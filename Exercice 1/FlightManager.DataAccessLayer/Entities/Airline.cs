using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightManager.DataAccessLayer.Entities
{
    public class Airline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirlineId { get; set; }
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
