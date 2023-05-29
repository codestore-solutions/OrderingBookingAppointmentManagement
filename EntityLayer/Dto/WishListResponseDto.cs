using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class WishListResponseDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}
