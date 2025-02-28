using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Services
{
    public class ShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<List<Shipper>> GetShippers()
        {
            return (List<Shipper>)await _shipperRepository.GetAll();
        }
    }
}
