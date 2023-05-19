using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CreateNewOrder
    { 
        public float OrderAmount { get; set; }
        public int OrderQty { get; set; }
        public Guid ShippingMethodId { get; set; }
        public Guid ShippingAddressID { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }

    }
}
