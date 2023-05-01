using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class TransportModel
    {
        public TransportModel(string flightCarrier, string flightNumber)
        {
            this.FlightCarrier = flightCarrier;
            this.FlightNumber = flightNumber;
        }
        public string FlightCarrier { get; set; } = string.Empty;

        public string FlightNumber { get; set; } = string.Empty;
    }
}
