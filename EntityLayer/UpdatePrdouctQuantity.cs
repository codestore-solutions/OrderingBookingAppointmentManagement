using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class UpdatePrdouctQuantity
    {
        [Required]
        [Range(1,5, ErrorMessage = "We are Sorry! Only 5 Units allowed in each Order")]
        public int ProductQuantity { get; set; }

        public long UserId { get; set; }
        public long ProductId { get; set; }
    }
}
