using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class WishlistCollection
    {
        public long WishlistCollectionId { get; set; }
        public long UserId { get; set; }
        public string CollectionName { get; set; } = null!;
        public List<WishlistItems> WishlistItems { get; set; } = new List<WishlistItems>();
    }
}
