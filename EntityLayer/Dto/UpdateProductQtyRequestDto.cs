using EntityLayer.Common;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class UpdateProductQtyRequestDto
    {
        [Required]
        public long CartItemId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = StringConstant.MaxQuantityMessage)]
        public int ProductQuantity { get; set; }
    }
}
