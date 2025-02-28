using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Application.Contracts
{
    public class CreateOrderDto
    {
        public Order Order { get; set; } = new();
        public OrderDetail OrderDetail { get; set; } = new();
    }
}
