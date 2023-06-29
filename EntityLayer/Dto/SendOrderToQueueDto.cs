using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class SendOrderToQueueDto
    {
        public long orderId { get; set; }
        public long customerId { get; set; }
        public long storeId { get; set; }
    }
}
