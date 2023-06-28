using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class ShippingAddress
    {
        [Key]
        public long ShippingAddressId { get; set; }
        public long UserId { get; set; }
        public ICollection<Address> Addresss { get; set; } = new List<Address>();
    }
}
