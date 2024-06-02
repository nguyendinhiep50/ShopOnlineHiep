using AutoMapper;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Category.Dtos
{
    public class CategoryUpdateDto
    {
        public Boolean? IsDeteted { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
    }

    public class CategoryAddDto : CategoryUpdateDto
    {
        public string? Id { get; set; } = string.Empty;
    }

    public class CategoryDto : CategoryUpdateDto
    {
        public Guid UId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedSpanTime { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedSpanTime { get; set; }

        public string? UpdatedBy { get; set; }
        private class CategoryProfile : Profile
        {
            public CategoryProfile()
            {
                CreateMap<Categories, CategoryDto>().ConvertUsing((entity, dto) =>
                {
                    return new CategoryDto
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
                CreateMap<CategoryDto, Categories>();
                CreateMap<CategoryUpdateDto, Categories>();
                CreateMap<CategoryAddDto, Categories>();
            }
        }

    }
}
