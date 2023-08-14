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
        public long UserId { get; set; }

        [Required]
        public long ProductId { get; set; }

        [Required]
        public long VariantId { get; set; }

        [Required]
        public long StoreId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }
        public long WishListCollectionId { get; set; }
    }
}
