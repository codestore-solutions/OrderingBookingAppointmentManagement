using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class ShippingMethod
    {
        public Guid ShippingMethodId { get; set; }
        public string Name { get; set; }
        public float price { get; set; }
    }
}
