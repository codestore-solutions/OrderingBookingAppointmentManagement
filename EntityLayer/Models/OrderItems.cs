using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class OrderItems
    {
        public int OrderItemsId { get; set; }
        public long ProductId { get; set; }
        public long? VarientId { get; set; }
        public long Price { get; set; }
        public double Discount { get; set; }
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
        public OrderStatus orderStatus { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = null!;

    }
}
