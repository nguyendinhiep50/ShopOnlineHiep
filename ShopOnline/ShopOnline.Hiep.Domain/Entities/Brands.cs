using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Brands : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
