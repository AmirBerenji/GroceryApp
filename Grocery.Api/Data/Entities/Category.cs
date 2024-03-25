using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Api.Data.Entities
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(150)]
        public string Image { get; set; }

        public int ParentId { get; set; }
        [MaxLength(100)]
        public string? Credit { get; set; }
    }
}
