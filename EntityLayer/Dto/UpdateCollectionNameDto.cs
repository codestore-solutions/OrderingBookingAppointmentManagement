using System.ComponentModel.DataAnnotations;

namespace Entitites.Dto
{
    public class UpdateCollectionNameDto
    {
        [Required]
        [StringLength(100)]
        public string CollectionName { get; set; } = null!;
    }
}
