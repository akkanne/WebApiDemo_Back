using AutoMapper;
using Business.Dtos;
using Entities;

namespace Business.Mapping
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            try {
                MapperConfiguration configuration = new MapperConfiguration(cfg =>
                    {
                        //IMappingExpression<Transport, TransportDto> mappingExpression = cfg.CreateMap<Transport, TransportDto>(); //GET
                        cfg.CreateMap<Transports, TransportDto>(); //GET
                        cfg.CreateMap<TransportDto, Transports>(); //POST - PUT
                    });
                configuration.AssertConfigurationIsValid();

                return configuration;
            }
            catch (Exception ex)
            {
                // Código que se ejecuta si se genera una excepción
                Console.WriteLine("Ha ocurrido una excepción: " + ex.Message);
                return null;
            }
            finally
            {
                // Código que siempre se ejecuta, tanto si se genera una excepción como si no
                Console.WriteLine("El bloque try-catch ha finalizado");
            }
        }
    }
}
