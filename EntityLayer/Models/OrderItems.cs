using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public long? VarientId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public double Discount { get; set; }

        [Required]
        public int Quantity { get; set; }
        public enum OrderStatus
        {
            NewCreated,
            Processing,
            Delivered,
            Returned,
            Replaced,
            Cancelled
        }

        [Required]
        public OrderStatus orderStatus { get; set; }

        [Required]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

    }
}
