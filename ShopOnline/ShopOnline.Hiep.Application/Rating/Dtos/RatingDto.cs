using AutoMapper;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Rating.Dtos
{
    public class RatingUpdateDto
    {
        public float? StarPoint { get; set; }
        public Boolean? IsDeteted { get; set; }
        public string UserId { get; set; } = string.Empty;
    }

    public class RatingAddDto : RatingUpdateDto
    {
        public string? Id { get; set; } = string.Empty;
    }

    public class RatingDto : RatingUpdateDto
    {
        public Guid UId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedSpanTime { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedSpanTime { get; set; }

        public string? UpdatedBy { get; set; }
        private class RatingProfile : Profile
        {
            public RatingProfile()
            {
                CreateMap<Ratings, RatingDto>().ConvertUsing((entity, dto) =>
                {
                    return new RatingDto
                    {
                        UserId = entity.UserId,
                        StarPoint = dto.StarPoint,
                        IsDeteted = dto.IsDeteted,
                        CreatedDate = entity.CreatedDate,
                        CreatedSpanTime = entity.CreatedSpanTime,
                        CreatedBy = entity.CreatedBy,
                        UpdatedDate = entity.UpdatedDate,
                        UpdatedSpanTime = entity.UpdatedSpanTime,
                        UpdatedBy = entity.UpdatedBy
                    };
                });
                CreateMap<RatingDto, Ratings>();
                CreateMap<RatingUpdateDto, Ratings>();
                CreateMap<RatingAddDto, Ratings>();
            }
        }

    }
}
