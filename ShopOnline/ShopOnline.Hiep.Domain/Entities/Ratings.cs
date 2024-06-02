using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Ratings : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public float? StarPoint { get; set; }
        public Boolean? IsDeteted { get; set; }
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = string.Empty;
    }
}
