using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Images : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? OriginLinkImage { get; set; } = string.Empty;
        public string? LocalLinkImage { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
    }
}
