using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
