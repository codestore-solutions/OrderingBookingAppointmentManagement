using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EntityLayer.Dto
{
    public class AddToCartRequestDto
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public long VariantId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

