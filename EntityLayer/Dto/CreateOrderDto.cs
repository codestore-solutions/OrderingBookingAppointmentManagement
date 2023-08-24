
using System.ComponentModel.DataAnnotations;
using static Entitites.Common.EnumConstants;

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
        public long ProductId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long VariantId { get; set; }

        // Added New Column
       /* [Required]
        public double MRPPrice { get; set; }*/

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Range(0, double.MaxValue)]   
        public double Discount { get; set; }

        [Required]
        [Range(1, int.MaxValue)]    
        public int Quantity { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }
    }
    public class CreateOrderDto
    {

        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

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

        //
       // public double TaxesAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public long DeliverySlotId { get; set; }

        [Required]
        public PaymentMode PaymentMode { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }
    }
}
