using AutoMapper;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Brand.Dtos
{
    public class BrandUpdateDto
    {
        public Boolean? IsDeteted { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
    }

    public class BrandAddDto : BrandUpdateDto
    {
        public string? Id { get; set; } = string.Empty;
    }

    public class BrandDto : BrandUpdateDto
    {
        public Guid UId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedSpanTime { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedSpanTime { get; set; }

        public string? UpdatedBy { get; set; }
        private class BrandProfile : Profile
        {
            public BrandProfile()
            {
                CreateMap<Brands, BrandDto>().ConvertUsing((entity, dto) =>
                {
                    return new BrandDto
                    {
                        Code = entity.Code,
                        Name = entity.Name,
                        UId = entity.UId,
                        IsDeteted = entity.IsDeteted,
                        CreatedDate = entity.CreatedDate,
                        CreatedSpanTime = entity.CreatedSpanTime,
                        CreatedBy = entity.CreatedBy,
                        UpdatedDate = entity.UpdatedDate,
                        UpdatedSpanTime = entity.UpdatedSpanTime,
                        UpdatedBy = entity.UpdatedBy
                    };
                });
                CreateMap<BrandDto, Brands>();
                CreateMap<BrandUpdateDto, Brands>();
                CreateMap<BrandAddDto, Brands>();
            }
        }

    }
}
