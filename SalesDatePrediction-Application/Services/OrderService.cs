using SalesDatePrediction_Application.Interfaces;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> AddReturn(Order order)
        {
            return await _orderRepository.AddReturn(order);
        }

        public async Task<List<Order>> GetOrders(int customerId)
        {
            return await _orderRepository.GetOrders(customerId);
        }
    }
}
