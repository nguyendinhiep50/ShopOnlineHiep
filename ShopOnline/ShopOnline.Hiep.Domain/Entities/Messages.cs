using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Messages : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? ChatMessages { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductId))]
        public string ProductId { get; set; } = string.Empty;
    }
}
