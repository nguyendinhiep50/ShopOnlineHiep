using AutoMapper;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Status.Dtos
{
    public class StatusUpdateDto
    {
        public string? Type { get; set; } = string.Empty;
        public string? Display { get; set; } = string.Empty;
        public string? Code { get; set; } = string.Empty;
    }

    public class StatusAddDto : StatusUpdateDto
    {
        public string? Id { get; set; } = string.Empty;
    }

    public class StatusDto : StatusUpdateDto
    {
        public Guid UId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedSpanTime { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedSpanTime { get; set; }

        public string? UpdatedBy { get; set; }
        private class StatusProfile : Profile
        {
            public StatusProfile()
            {
                CreateMap<Statuses, StatusDto>().ConvertUsing((entity, dto) =>
                {
                    return new StatusDto
                    {
                        Code = entity.Code,
                        Display = entity.Display,
                        Type = entity.Type,
                        UId = dto.UId,
                        CreatedDate = entity.CreatedDate,
                        CreatedSpanTime = entity.CreatedSpanTime,
                        CreatedBy = entity.CreatedBy,
                        UpdatedDate = entity.UpdatedDate,
                        UpdatedSpanTime = entity.UpdatedSpanTime,
                        UpdatedBy = entity.UpdatedBy
                    };
                });
                CreateMap<StatusDto, Statuses>();
                CreateMap<StatusUpdateDto, Statuses>();
                CreateMap<StatusAddDto, Statuses>();
            }
        }

    }
}
