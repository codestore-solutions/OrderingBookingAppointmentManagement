using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entitites.Common.EnumConstants;

namespace Entitites.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ProductId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long VariantId { get; set; }

        // Added a new Column
       /* [Required]
        public double MRPPrice { get; set; }*/

       /* [Required]
        [Range(0, double.MaxValue)]
        public double DiscountedPrice { get; set; }           // Price after discount */

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public double Discount { get; set; }                 // Discount Amount
      
        [Required]
        public int Quantity { get; set; }
      
        [Required]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

    }
}
