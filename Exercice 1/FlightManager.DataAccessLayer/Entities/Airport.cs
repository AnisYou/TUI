using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightManager.DataAccessLayer.Entities
{
    [Table("Airport")]
   public class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirportId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string Timezone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        [InverseProperty("To")]
        public virtual ICollection<Flight> Arrivals { get; set; }
        [InverseProperty("From")]
        public virtual ICollection<Flight> Departures { get; set; }
    }
}
