using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class UpdateProductQtyRequestDto
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "We are Sorry! Only 10 Units allowed in each Order")]
        public int ProductQuantity { get; set; }

    }
}
