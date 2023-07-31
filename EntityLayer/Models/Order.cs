using Entitites.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Models
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Required] 
        [Range(1, long.MaxValue)]
        public long ShippingAddressId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ProductCount { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long VendorId { get; set; }

        [Required]
        [Range(0.0, double.MaxValue)]
        public double DeliveryCharges { get; set; }

        [Required]
        public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

        [Required]
        [Range(1, long.MaxValue)]
        public long PaymentId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        public double TipAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }
        public enum PaymentStatus
        {
            Failed     = 0,
            Successful = 1,
            Pending    = 2          
        }   

        public enum PaymentMode
        {
            Online = 1,
            COD    = 2
        }

        public enum DeliverySlots
        {
            None        = 0,
            E6AmTo10Am  = 1,
            E10AmTo2Pm  = 2,
            E2PmTo6Pm   = 3,
            E6PmTo10Pm  = 4,
        }
        public DeliverySlots DeliverySlot { get; set; }

        [Required]
        public PaymentMode paymentMode { get; set; }

        [Required]
        public PaymentStatus paymentStatus { get; set; }
    }
}



