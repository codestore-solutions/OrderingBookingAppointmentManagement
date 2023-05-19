
namespace EntityLayer.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public Guid OrderLineItemsId { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }  
    }
}
