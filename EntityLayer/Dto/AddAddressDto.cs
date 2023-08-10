using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entitites.Common.EnumConstants;

namespace Entitites.Dto
{
    public class AddAddressDto
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
        [StringLength (10)]
        public string CountryCode { get; set; } = null!;

        [Required]
        [StringLength(25)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [StringLength(15, MinimumLength =10)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(15, MinimumLength = 10)]
        [Phone]
        public string? AlternateNumber { get; set; }

        public AddressesType AddressType { get; set; }

        [Range(0.0, 100.0)]
        public double Latitude { get; set; }

        [Range(0.0, 100.0)]
        public double Longitude { get; set; }
    }
}
