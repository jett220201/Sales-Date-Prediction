using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("Production.Suppliers")]
    public class Supplier
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string? Fax { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
