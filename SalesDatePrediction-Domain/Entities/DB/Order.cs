using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("Sales.Orders")]
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly RequiredDate { get; set; }
        public DateOnly? ShippedDate { get; set; }
        public int ShipperId { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Shipper? Shipper { get; set; }
        public virtual ICollection<OrderDetail>? Details { get; set; }
    }
}
