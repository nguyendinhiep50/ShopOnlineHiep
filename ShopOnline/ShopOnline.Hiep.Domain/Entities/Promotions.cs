using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Promotions : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public string? DiscountPercent { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
