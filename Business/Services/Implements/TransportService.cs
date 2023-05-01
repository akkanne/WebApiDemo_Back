using DataAccess.Repository;
using DataAccess.Repository.Implements;
using Entities;

namespace Business.Services.Implements
{
    public class TransportService: GenericService<Transports>, ITransportService
    {
        private ITransportRepository transportRepository;
        public TransportService(ITransportRepository transportRepository) : base(transportRepository)
        {
            this.transportRepository = transportRepository;
        }
    }
}
