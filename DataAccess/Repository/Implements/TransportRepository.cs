using Entities;

namespace DataAccess.Repository.Implements
{
    public class TransportRepository : GenericRepository<Transports>  , ITransportRepository 
    {
        public TransportRepository(APIDbContext aPIDbContext) : base(aPIDbContext) { }
    }
}
