using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{

    public class AddWishListRequestDto
    {
        public long? ProductId { get; set; }
        public long? VarientId { get; set; }

        [Required]
        public long UserId { get; set; }

    }
}
