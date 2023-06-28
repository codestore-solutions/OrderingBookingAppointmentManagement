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
        public long ProductId { get; set; }
        public long? VarientId { get; set; }
        public long StoreId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public long WishListCollectionId { get; set; }
    }
}
