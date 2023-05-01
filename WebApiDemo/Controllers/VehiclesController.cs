using AutoMapper;
using Business.Dtos;
using Business.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Business.Mapping;
using System.Security.Cryptography.Xml;
using Microsoft.Extensions.Logging.TraceSource;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        //private readonly ILoggerManager _logger;
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        /*public TransportsController(ILoggerManager logger, ITransportService transportService)
        {
            _logger = logger;
            _transportService = transportService;
        3+9
        }*/
        public VehiclesController(IVehicleService vehicleService, IMapper mapper)
        {
            this._vehicleService = vehicleService;
            this._mapper = mapper;
        }


        [HttpGet(Name = "GetAllVehicles")]
        public async Task<List<VehicleDto>> GetAllVehiclesAsync()
        {
            List<VehicleDto> lstVehicleDtos = new List<VehicleDto>();

            IEnumerable<Vehicles> vehicles = await _vehicleService.GetAll();


            var data = _mapper.Map<List<VehicleDto>>(vehicles);

            return data;
        }

        [HttpGet("{id}", Name = "VehicleById")]
        public async Task<IActionResult> GetById(int id)
        {
            Vehicles vehicles = await _vehicleService.GetById(id);
            if (vehicles == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            var data = _mapper.Map<VehicleDto>(vehicles);
            return Ok(data);  // Returns an OkNegotiatedContentResult
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleDto vehicleDto)
        {
            Vehicles vehicle = _mapper.Map<Vehicles>(vehicleDto);
            vehicle = await _vehicleService.Insert(vehicle);
            if (vehicle == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            var id = vehicle.Id;
            VehicleDto data = _mapper.Map<VehicleDto>(vehicle);
            return Ok(data);  // Returns an OkNegotiatedContentResult
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(VehicleDto vehicleDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Vehicles vehicle = _mapper.Map<Vehicles>(vehicleDto);
                var vehicleO = await _vehicleService.Update(vehicle);
                if (vehicleO == null)
                {
                    return NotFound(); // Returns a NotFoundResult
                }
                var id = vehicleO.Id;
                VehicleDto data = _mapper.Map<VehicleDto>(vehicleO);
                return Ok(data);  // Returns an OkNegotiatedContentResult
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Method 
        /// Realiza el borrade de vehículos{id}
        /// </summary>
        [HttpDelete("{id:int}", Name = "DeleteVehicle")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleService.GetById(id);

            if (vehicle == null)
            {
                return NotFound();

            }

            try
            {
                await _vehicleService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
