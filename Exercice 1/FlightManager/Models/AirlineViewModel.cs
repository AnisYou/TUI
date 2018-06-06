using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models
{
    public class AirlineViewModel
    {
    
        public int AirlineId { get; set; }
        public string AirlineCode { get; set; }
        [Display(Name = "Operated by")]
        public string AirlineName { get; set; }
    }
}