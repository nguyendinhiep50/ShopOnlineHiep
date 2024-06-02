using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Products :BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public float? Price { get; set; }
        public float? Discount { get; set; }
        public float? Currency { get; set; }
        public string? DefaultImage { get; set; } = string.Empty;
        public string? OriginLinkDetail { get; set; } = string.Empty;
        public string? Url { get; set; } = string.Empty;
        public string? Stock { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; } = new List<Ratings>();
        public virtual ICollection<Properties> Properties { get; set; } = new List<Properties>();
        public virtual ICollection<Images> Images { get; set; } = new List<Images>();
        public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
        public virtual ICollection<Messages> Messages { get; set; } = new List<Messages>();


    }
}
