using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class AddProductInOrderLine
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}

