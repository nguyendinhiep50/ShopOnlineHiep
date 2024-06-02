using ShopOnline.Hiep.Application.Common.Models;

namespace ShopOnline.Hiep.Application.Rating.Dtos
{
    public class RatingPagingFilterDto : PagingFilterModel
    {
        public string? SearchText { get; set; }
        public bool? Status { get; set; }
        public int? GroupType { get; set; }
    }
}
