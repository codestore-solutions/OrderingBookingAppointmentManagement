using Entitites.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Entitites.Common.EnumConstants;

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

        //
      /*  public double ItemTotal { get; set; }
        public double TotalInvoiceAmount { get; set; }
        public double TaxesAmount { get; set; }*/
        
        [Required]
        [Range(0.0, double.MaxValue)]
        public double DeliveryCharges { get; set; }

        [Required]
        public double TipAmount { get; set; }

        [Required]
        public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

        [Required]
        public long PaymentId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Column(TypeName = "date")]
        public DateTime DeliveryDate { get; set; }
        public long DeliverySlotId { get; set; }
       
        [Required]
        public PaymentMode paymentMode { get; set; }

        [Required]
        public PaymentStatus paymentStatus { get; set; }
    }
}



