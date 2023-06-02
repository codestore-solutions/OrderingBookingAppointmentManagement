using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class WishList
    {
        [Key]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long UserId { get; set; }
     //   public double Price { get; set; }                                              // as prices may vary with time
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;                // might be helpful in logging to fetch the insights 
 

    }
}
