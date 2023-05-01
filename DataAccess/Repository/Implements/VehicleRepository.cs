using Entities;

namespace DataAccess.Repository.Implements
{
    public class VehicleRepository : GenericRepository<Vehicles>, IVehicleRepository
    {
        public VehicleRepository(APIDbContext aPIDbContext) : base(aPIDbContext) { }
    }
}
