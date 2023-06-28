using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Address
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Street { get; set; } = null!;

        [StringLength(20)]
        public string City { get; set; } = null!;

        [StringLength(20)]
        public string State { get; set; } = null!;
        public string Country { get; set; } = null !;

        [Required]
        public string CountryCode { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;
        public string? AlternateNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long ShippingAddressId { get; set; } 
        public ShippingAddress ShippingAddress { get; set; } = null!;
    }
}
