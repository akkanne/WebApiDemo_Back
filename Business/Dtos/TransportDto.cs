using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos
{
    public class TransportDto
    {
        public TransportDto()
        {
        }

        public TransportDto(string flightCarrier, string flightNumber)
        {
            this.FlightCarrier = flightCarrier;
            this.FlightNumber = flightNumber;
        }

        [Required(ErrorMessage = "FlightCarrier is required")]
        [StringLength(50)]
        public string FlightCarrier { get; set; }

        [Required(ErrorMessage = "FlightNumber is required")]
        [StringLength(50)]
        public string FlightNumber { get; set; } 

        public string dataFlight { 
            get{ return string.Format("{0} {1}", FlightCarrier, FlightNumber);}
        }
    }
}
