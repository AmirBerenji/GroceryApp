using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Api.Data.Entities
{
    [Table(nameof(Address))]
    public class Address 
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required,MaxLength(150)]
        public string Address1 { get; set; }
        [MaxLength(150)]
        public string? Address2 { get; set; }
        [Required,MaxLength(10)]
        public string Zip { get; set; }
        public bool IsPrimary { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public virtual User User { get; set; }
    }
}
