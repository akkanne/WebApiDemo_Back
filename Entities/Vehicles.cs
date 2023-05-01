using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Vehicles
    {
        [Key]
        public int Id { get; set; }
        public int IdVehicleType { get; set; }

        [Required]
        public int Model { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string LicensePlate { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Color { get; set; } = string.Empty;

        [Required]
        public int NumberPassengers { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Photo { get; set; } = string.Empty;

        //public virtual VehicleTypes? VehicleType { get; set; } 

    }
}