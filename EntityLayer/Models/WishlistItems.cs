using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class WishlistItems
    {
        public long WishlistItemsId { get; set; }
        public long ProductId { get; set; }
        public long VarientId { get; set; }
        public long StoreId { get; set; }

        // Helpful to inform users about price drops
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public long WishListCollectionId { get; set; }
        public virtual WishlistCollection WishlistCollection { get; set; } = null!;

    }
}
