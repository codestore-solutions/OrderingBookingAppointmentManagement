using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class UpdateAddressDto
    {
        [Required(ErrorMessage = "The Street field is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "The City field is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "The State field is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "The Country field is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "The PostalCode field is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = "The PhoneNumber field is required.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(10, MinimumLength = 1, ErrorMessage = "The property must be a string.")]
        public string? AlternateNumber { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "The property must be between 0.0 and 100.0.")]
        public double Latitude { get; set; }

        [Range(0.0, 100.0, ErrorMessage = "The property must be between 0.0 and 100.0.")]
        public double Longitude { get; set; }
    }
}
