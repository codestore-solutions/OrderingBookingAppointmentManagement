using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AddProductInWishList
    {       
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public double Price { get; set; }   // as prices may vary with time
    }
}
