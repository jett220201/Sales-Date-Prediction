using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrderDetail
    {
        [Key]
        [Column(Order=1)]
        public int OrderId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
