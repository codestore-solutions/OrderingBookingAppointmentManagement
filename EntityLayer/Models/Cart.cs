using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public ICollection<CartItems> CartItems { get; set; } = new List<CartItems>();     // Collection navigation property
    }
}




