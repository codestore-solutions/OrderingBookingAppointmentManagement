using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class OrderLineItems
    {
        [Required]
        public Guid OrderLineItemsId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public double ProductPrice { get; set;}

        [Required]
        public int ProductQuantity { get; set; }
       
    }
}
































// public Guid UserId { get; set; }
//public List<Product> ProductIds { get; set; }




