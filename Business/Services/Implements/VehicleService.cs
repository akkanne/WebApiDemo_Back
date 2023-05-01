using DataAccess.Repository;
using DataAccess.Repository.Implements;
using Entities;

namespace Business.Services.Implements
{
    public class VehicleService : GenericService<Vehicles>, IVehicleService
    {
        private IVehicleRepository vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository) : base(vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }
    }
}
