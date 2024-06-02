using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Brand.Commands;
using ShopOnline.Hiep.Application.Brand.Dtos;
using ShopOnline.Hiep.Application.Brand.Queries;
using ShopOnline.Hiep.Application.Category.Dtos;

namespace ShopOnline.Hiep.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class BrandController : ApiControllerBase
    {
        [HttpGet]
        public Task<PaginatedList<BrandDto>> Get([FromQuery] BrandPagingFilterDto filter)
        {
            return Mediator.Send(new GetBrandQuery
            {
                Filter = filter
            });
        }

        [HttpGet("{id}")]
        public Task<BrandDto> GetById([FromRoute] string id)
        {
            return Mediator.Send(new GetBrandByBrandCodeQuery
            {
                Id = id
            });
        }

        [HttpPost]
        public Task<ResponseModel<bool>> CreateBrandAsync([FromBody] BrandAddDto writeDto)
        {
            return Mediator.Send(new CreateBrandCommand
            {
                Dto = writeDto
            });
        }

        [HttpPut("{id}")]
        public async Task<ResponseModel<bool>> UpdateBrandAsync([FromRoute] string id, [FromBody] BrandUpdateDto writeDto)
        {
            return await Mediator.Send(new UpdateBrandCommand
            {
                Id = id,
                Dto = writeDto
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel<bool>> DeleteBrandAsync([FromRoute] string id)
        {
            return Mediator.Send(new DeleteBrandCommand
            {
                Id = id
            });
        }
    }
}
