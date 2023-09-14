using System.ComponentModel.DataAnnotations;

namespace Entitites.Dto
{
    public class UpdateQuantityDto
    {
        [Required]
        public int Quantity { get; set; }
    }
}
