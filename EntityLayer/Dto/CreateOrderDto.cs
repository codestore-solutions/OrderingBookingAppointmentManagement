﻿
using System.ComponentModel.DataAnnotations;

namespace Entitites.Dto
{
    public class OrdersForVendorsDto
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long VendorId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double DeliveryCharges { get; set; }

        [Required]
        public List<OrderItemsDto> OrderItems { get; set; } = new List<OrderItemsDto>();
    }
    public class OrderItemsDto
    {
        [Required]
        [Range(1, long.MaxValue)]
        [DataType("long")]
        public long ProductId { get; set; }

        [Required]
        public long? VarientId { get; set; }

        [Required]
        [Range(0, long.MaxValue)]
        public long Price { get; set; }

        [Required]
        [Range(0, double.MaxValue)]   
        public double Discount { get; set; }

        [Required]
        [Range(1, int.MaxValue)]    
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
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set;}

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        public List<OrdersForVendorsDto> OrdersForVendors { get; set; } = new List<OrdersForVendorsDto>();

        [Required]
        [Range(1, long.MaxValue)]
        public long PaymentId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ShippingAddressId { get; set; }

        [Range(0 , double.MaxValue)]     
        public double TipAmount { get; set; }

        /*[DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }*/
        public enum DeliverySlots
        {
            Default10Am = 0,
            E6AmTo10Am = 1,
            E10AmTo2Pm = 2,
            E2PmTo6Pm = 3,
            E6PmTo10Pm = 4,
        }
        public DeliverySlots DeliverySlot { get; set; }
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
