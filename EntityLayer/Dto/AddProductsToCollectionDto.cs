using Entitites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class AddProductsToCollectionDto
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ProductId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long VariantId { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long StoreId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long WishListCollectionId { get; set; }
    }
}
