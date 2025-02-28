namespace SalesDatePrediction_Domain.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateOnly LastOrderDate { get; set; }
        public DateOnly NextPredictedOrderDate { get; set; }
    }
}
