using ShopOnline.Hiep.Application.Common.Models;

namespace ShopOnline.Hiep.Application.Status.Dtos
{
    public class StatusPagingFilterDto : PagingFilterModel
    {
        public string? SearchText { get; set; }
        public bool? Status { get; set; }
        public int? GroupType { get; set; }
    }
}
