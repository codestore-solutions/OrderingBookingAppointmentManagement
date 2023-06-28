using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class WishlistCollectionDto
    {
        public long UserId { get; set; }
        public string CollectionName { get; set; } = null!;
    }
}
