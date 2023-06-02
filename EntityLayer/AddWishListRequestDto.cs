using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AddWishListRequestDto
    {
        [Required]
        public long ProductId { get; set; }

        [Required]
        public long UserId { get; set; }
        
    }
}
