using Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Dtos
{
    /// <summary>
    /// Data Transfer Object Vehiculos
    /// Clase para presentación de información hacia el cliente
    /// </summary>
    public class VehicleDto
    {
        public VehicleDto()
        {
        }

        public VehicleDto(int idVehicleType, int model, string licensePlate, string color, int numPassengers,
            string photo)
        {
            this.IdVehicleType = idVehicleType;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.Color = color;
            this.NumberPassengers = numPassengers;
            this.Photo = photo;

        }
        /// <summary>
        /// Id de la categoria
        /// </summary>
        /// <value>El Id se incrementa automáticamente</value>
        public int Id { get; set; }
        /// <summary>
        /// Obtiene o establece el tipo de vehúiculo
        /// </summary>
        /// <value>id del tipo de vehículo</value>
        public int IdVehicleType { get; set; }

        /// <summary>
        /// Obtiene o establece el año de fabricación del vehículo
        /// </summary>
        /// <value>año del vehículo</value>
        [Required(ErrorMessage = "Model is required")]
        public int Model { get; set; }
        /// <summary>
        /// Obtiene o establece el numero de placa o matricula
        /// </summary>
        /// <value>Placa del vehículo</value>
        [Required(ErrorMessage = "License Plate is required")]
        [StringLength(50)]
        public string LicensePlate { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el color del vehículo
        /// </summary>
        /// <value>Color del vehículo</value>
        [Required(ErrorMessage = "Color is required")]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece la capacidad de pasajeros
        /// </summary>
        /// <value>Cantidad de Pasajeros</value>
        [Required(ErrorMessage = "Number of passengers is required")]
        public int NumberPassengers { get; set; }

        /// <summary>
        /// Obtiene o establece la foto de la imagen
        /// </summary>
        /// <value>Foto</value>
        [Required(ErrorMessage = "Photo is required")]
        [StringLength(50)]
        public string Photo { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece del tipo de vehículo
        /// </summary>
        /// <value></value>
        public string dataVehicleType
        {
            get { return string.Format("{0}", IdVehicleType); }
        }
    }
}