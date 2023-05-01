using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class VehicleTypes
    {
        [Key]
        public int IdVehicleType { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; } = string.Empty;


    }
}