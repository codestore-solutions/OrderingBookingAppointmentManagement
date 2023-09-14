﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Dto
{
    public class AddToCartRequestDto
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
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}

