using System.ComponentModel.DataAnnotations;

namespace Entitites.Models
{
    public class WishlistItems
    {
        [Key]
        public long WishlistItemsId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public long VarientId { get; set; }

        [Required]
        public long StoreId { get; set; }        // need to update storeId -> vendorId

        // Helpful to inform users about price drops

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        /* [Required]
         public DateTime LastUpdatedOn { get; set; }*/

        [Required]
        public long WishListCollectionId { get; set; }
        public virtual WishlistCollection WishlistCollection { get; set; } = null!;

    }
}
