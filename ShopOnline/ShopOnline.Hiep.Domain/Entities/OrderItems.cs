using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class OrderItems : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public float? Quantity { get; set; }
        public float? Price { get; set; }
        public Boolean? IsDeteted { get; set; }
    }
}
