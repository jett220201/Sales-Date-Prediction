using SalesDatePrediction_Application.Interfaces;

namespace SalesDatePrediction_Application.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
    }
}
