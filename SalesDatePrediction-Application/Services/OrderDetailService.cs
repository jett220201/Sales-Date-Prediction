using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Services
{
    public class OrderDetailService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<OrderDetail> AddReturn(OrderDetail orderDetail)
        {
            return await _orderDetailsRepository.AddReturn(orderDetail);
        }
    }
}
