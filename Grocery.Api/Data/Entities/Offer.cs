using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Api.Data.Entities
{
    [Table(nameof(Offer))]
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string BgColor { get; set; }

        public bool IsActive { get; set; }
    }
}
