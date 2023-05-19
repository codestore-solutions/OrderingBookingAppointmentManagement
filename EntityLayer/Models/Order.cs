using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public float OrderAmount { get; set; }
        public int OrderQty { get; set; }   
        public Guid OrderLineItemsId { get; set; }                                                     
        public Guid ShippingMethodId { get; set; } 
        public Guid ShippingAddressID { get; set; } 
        public Guid PaymentId { get; set; }
        public Guid ProductId { get; set;}
        public Guid UserId { get; set; } 
        enum PaymentStatus
        {
            Pending,
            Successful,
            Failed
        }
        enum OrderStatus
        {
            Processing,
            Shipped,
            Delivered,
            Returned,
            Replaced
        }      


    }
}


 




















/* enum OrderStatus
       {
           OrderProcessing,
           failed,
           Cancelled,
           Shipped,
           Delivered,
           Return,
           Replace
       }

  // Navigation Properties
        public Payment? Payment { get; set; }
        public User User { get; set; }  
        public ShippingMethod? ShippingMethod { get; set; }
        public ShippngAddress? ShippngAddress { get; set; }
        public Product Product { get; set; } 




*/