using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Orders : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
        public string? CustomerName { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public int? TotalAmount { get; set; } 
        public string? Note { get; set; } = string.Empty;
        public string? CancelReason { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    }
}
