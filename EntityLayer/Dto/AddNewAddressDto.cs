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
        [StringLength(100, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string Street { get; set; } = null!;

        [Required]
        [StringLength(25, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(25, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string State { get; set; } = null!;

        [Required]
        [StringLength(25, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string Country { get; set; } = null!;

        [Required]
        public string CountryCode { get; set; } = null!;

        [Required]
        [StringLength(25, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string PostalCode { get; set; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(10, MinimumLength = 1, ErrorMessage = StringConstant.StringMessage)]
        public string? AlternateNumber { get; set; }

        [Range(0.0, 100.0)]
        public double Latitude { get; set; }

        [Range(0.0, 100.0)]
        public double Longitude { get; set; }
    }
}
