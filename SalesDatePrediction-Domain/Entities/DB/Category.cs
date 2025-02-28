using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("")]
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
