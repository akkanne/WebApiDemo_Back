using AutoMapper;
using Business.Dtos;
using Business.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Business.Mapping;
using System.Security.Cryptography.Xml;
using Microsoft.Extensions.Logging.TraceSource;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        //private readonly ILoggerManager _logger;
        private readonly ITransportService _transportService;
        private readonly IMapper _mapper;


        /*public TransportsController(ILoggerManager logger, ITransportService transportService)
        {
            _logger = logger;
            _transportService = transportService;
        }*/
        public TransportsController(ITransportService transportService, IMapper mapper)
        {
            this._transportService = transportService;
            this._mapper = mapper;
        }


        [HttpGet(Name = "GetAllTransports")]
        public async Task<List<TransportDto>> GetAllTransportsAsync()
        {
            List<TransportDto> lstTransportDtos = new List<TransportDto>();

            IEnumerable<Transports> transports = await _transportService.GetAll();
            
    
            var data = _mapper.Map<List<TransportDto>>(transports);

            return data;
        }

        [HttpGet("{id}", Name = "TransportById")]
        /*public IActionResult GetById(int id)
        {
        }*/
        public async Task<IActionResult> GetById(int id)
        {
            Transports transports = await _transportService.GetById(id);
            if (transports == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            var data = _mapper.Map<TransportDto>(transports);
            return Ok(data);  // Returns an OkNegotiatedContentResult
        }
    }
}
