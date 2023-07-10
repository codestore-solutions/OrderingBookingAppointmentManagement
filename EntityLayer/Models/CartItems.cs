using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class CartItems
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public virtual Cart Cart { get; set; } = null!;                   // Navigation property to cart
        public long ProductId { get; set; }
        public long Quantity { get; set; }
        public long? VarientId { get; set; }
    }  

}


