using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesDatePrediction_Domain.Entities.DB
{
    [Table("HR.Employees")]
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleCourtesy { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int? ManagerId { get; set; }

        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Employee>? Subordinates { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
