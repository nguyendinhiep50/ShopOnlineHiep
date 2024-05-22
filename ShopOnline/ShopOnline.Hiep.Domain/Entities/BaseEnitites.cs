namespace ShopOnline.Hiep.Domain.Entities
{
    public class BaseEnitites
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedSpanTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedSpanTime { get; set; }
        public string? UpdatedBy { get; set; }
        public Boolean Status { get; set; }
        public Guid UId { get; set; }
    }
}
