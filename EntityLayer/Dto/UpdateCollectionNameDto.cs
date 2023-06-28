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
        [StringLength(50, MinimumLength =1,ErrorMessage ="Maximum 50 Characters are allowed")]
        public string CollectionName { get; set; } = null!;
    }
}
