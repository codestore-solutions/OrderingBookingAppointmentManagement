
using System.ComponentModel.DataAnnotations;

namespace Entitites.Dto
{
    public class OrdersForVendorsDto
    {
        [Required]
        public long VendorId { get; set; }

        [Required]
        public double DeliveryCharges { get; set; }

        [Required]
        public List<OrderItemsDto> OrderItems { get; set; } = new List<OrderItemsDto>();
    }
    public class OrderItemsDto
    {
        [Required]
        [DataType("long")]
        public long ProductId { get; set; }

        [Required]
        public long? VarientId { get; set; }

        [Required]
        public long Price { get; set; }

        [Required]
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
    }
    public class CreateOrderDto
    {

        [Required]
        public long UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set;}

        [Required]
        public List<OrdersForVendorsDto> OrdersForVendors { get; set; } = new List<OrdersForVendorsDto>();

        [Required]
        public long PaymentId { get; set; }

        [Required]
        public long ShipingAddressId { get; set; }

        public enum PaymentStatus
        {
            Failed = 0,
            Pending = 2,
            Successful = 1,
        }
        public enum PaymentMode
        {
            Online = 1,
            COD = 2
        }

        [Required]
        public PaymentMode paymentMode { get; set; }

        [Required]
        public PaymentStatus paymentStatus { get; set; }
    }
}
