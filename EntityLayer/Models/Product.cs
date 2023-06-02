
using System.Collections.ObjectModel;

namespace EntityLayer.Models
{
    public class Product
    {
        public long Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; } = null!;
    }
}
