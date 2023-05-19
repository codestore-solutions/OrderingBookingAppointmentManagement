using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class ShippngAddress
    {
        [Key]
        public Guid ShippingAddressId { get; set; }
    }
}
