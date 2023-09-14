namespace Entitites.Models
{
    public class WishlistCollection
    {
        public long WishlistCollectionId { get; set; }
        public long UserId { get; set; }
        public string CollectionName { get; set; } = null!;
        public virtual ICollection<WishlistItems> WishlistItems { get; set; } = new List<WishlistItems>();
    }
}
