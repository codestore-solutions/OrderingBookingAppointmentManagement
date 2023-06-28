using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class GetAddressesInBulkDto
    {
        //public List<long> UserIds { get; set; } = null!;
        public List<long> ShippingAddressIds { get; set; } = null!;
    }
}
