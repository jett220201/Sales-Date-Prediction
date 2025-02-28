using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("Production.Products")]
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public bool Discontinued { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
