using System.ComponentModel.DataAnnotations;

namespace Entitites.Dto
{
    public class WishlistCollectionDto
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string CollectionName { get; set; } = null!;
    }
}
