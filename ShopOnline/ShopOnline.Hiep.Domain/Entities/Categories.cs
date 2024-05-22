using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Categories : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
    }
}
