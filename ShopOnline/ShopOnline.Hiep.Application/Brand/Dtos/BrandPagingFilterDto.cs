using ShopOnline.Hiep.Application.Common.Models;

namespace ShopOnline.Hiep.Application.Category.Dtos
{
    public class BrandPagingFilterDto : PagingFilterModel
    {
        public string? SearchText { get; set; }
        public bool? Status { get; set; }
        public int? GroupType { get; set; }
    }
}
