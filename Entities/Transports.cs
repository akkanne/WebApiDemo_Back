using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Transports
    {
        [Key]
        public int TransportId { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string FlightCarrier { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string FlightNumber { get; set; } = string.Empty;

    }
}