using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class WishList
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public double Price { get; set; }                                              // as prices may vary with time
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;                // might be helpful in logging to fetch the insights 
       // public List<Product> ProductIds { get; set; }

    }
}
