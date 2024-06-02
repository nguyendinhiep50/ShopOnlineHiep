using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Properties : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public double? Value { get; set; }
        public Boolean? IsDeteted { get; set; }

    }
}
