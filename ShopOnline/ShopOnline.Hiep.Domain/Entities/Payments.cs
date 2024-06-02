using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Hiep.Domain.Entities
{
    public class Payments : BaseEnitites
    {
        [Key]
        public string? Id { get; set; } = string.Empty;
        public float? Amount { get; set; }
        public string? PaymentMethod { get; set; } = string.Empty;
        public string? TransactionId { get; set; } = string.Empty;
        public string? PaymentCode { get; set; } = string.Empty;
        public string? TransactionDate { get; set; } = string.Empty;
        public string? Fee { get; set; } = string.Empty;
        public Boolean? IsDeteted { get; set; }
        public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();


    }
}
