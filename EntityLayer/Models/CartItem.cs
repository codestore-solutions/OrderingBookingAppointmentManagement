using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class CartItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public long VariantId { get; set; }
    }

}


