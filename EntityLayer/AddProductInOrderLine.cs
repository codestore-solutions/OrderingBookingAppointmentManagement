using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace EntityLayer
{
    public class AddProductInOrderLine
    {
        [Required]
        public long ProductId { get; set; }
        public long UserId { get; set; }
        public int ProductQuantity { get; set; }
    }
}

