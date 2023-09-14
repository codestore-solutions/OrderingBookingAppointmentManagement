using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class AddWishListRequestDto
    {
        [Required]
        public long? ProductId { get; set; }

        [Required]
        public long? VarientId { get; set; }

        [Required]
        public long UserId { get; set; }

    }
}
