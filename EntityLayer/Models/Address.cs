using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entitites.Common.EnumConstants;

namespace EntityLayer.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

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
        public string Country { get; set; } = null !;

        [Required]
        [StringLength (20)]
        public string CountryCode { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;
        public string? AlternateNumber { get; set; }

        [Required]
        public AddressesType AddressType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
