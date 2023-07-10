using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class AddNewAddressDto
    {
        [Required]
        [StringLength(200)]
        public string Street { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string State { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\+91$")]
        public string CountryCode { get; set; } = null!;

        [Required]
        [StringLength(25)]
        [RegularExpression(@"^\d{6}$")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = StringConstant.PositiveAllowed)]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(25)]
        public string? AlternateNumber { get; set; }

        public enum AddressesType
        {
            ShippingAddress = 1,
            BillingAddress = 2
        }

        public AddressesType AddressType { get; set; }

        [Range(0.0, 100.0)]
        public double Latitude { get; set; }

        [Range(0.0, 100.0)]
        public double Longitude { get; set; }
    }
}
