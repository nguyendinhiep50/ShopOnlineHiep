using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Statuses :BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;
        public string? Display { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
        public virtual ICollection<Payments> Payments { get; set; } = new List<Payments>();

    }
}
