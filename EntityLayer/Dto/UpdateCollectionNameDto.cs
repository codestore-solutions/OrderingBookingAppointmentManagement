using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dto
{
    public class UpdateCollectionNameDto
    {
        [Required]
        [StringLength(100)]
        public string CollectionName { get; set; } = null!;
    }
}
