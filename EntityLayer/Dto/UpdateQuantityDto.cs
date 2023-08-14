using System.ComponentModel.DataAnnotations;

namespace Entitites.Dto
{
    public class UpdateQuantityDto
    {
        /* [Required]
         public long? VarientId { get; set; }

         [Required]
         public long ProductId { get; set; }*/

        [Required]
        public int Quantity { get; set; }
    }
}
