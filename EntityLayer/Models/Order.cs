using Entitites.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class Order
    {
        [Key]
        [Required]
        [Range(1, long.MaxValue)]
        public long OrderId { get; set; }

        [Required] [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Required] [Range(1, long.MaxValue)]
        public long ShippingAddressId { get; set; }

        [Required] [Range(1, long.MaxValue)]
        public long ProductCount { get; set; }

        [Required] [Range(1, long.MaxValue)]
        public long VendorId { get; set; }

        [Required][Range(0.0, double.MaxValue)]
        public double DeliveryCharges { get; set; }

        [Required]
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

        [Required][Range(1, long.MaxValue)]
        public long PaymentId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        public enum PaymentStatus
        {
            Failed =0,
            Pending=2,
            Successful=1,    
        }   
        public enum PaymentMode
        {
            Online =1,
            COD =2
        }

        [Required]
        public PaymentMode paymentMode { get; set; }

        [Required]
        public PaymentStatus paymentStatus { get; set; }
    }
}



