using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class UpdateQuantityDto
    {
        [Required]
        public long? VarientId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "We are Sorry! Only 10 Units allowed in each Order")]
        public int ProductQuantity { get; set; }
    }
}
