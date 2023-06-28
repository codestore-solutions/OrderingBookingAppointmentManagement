using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class UpdateOrder
    {
        [Required]
        public Guid ShippingMethodId { get; set; }

        [Required]
        public int OrderQty { get; set; }

        [Required]
        public Guid ShippingAddressID { get; set; }
    }
}

