using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class WishListResponseDto
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long ProductId { get; set; }
    }
}
