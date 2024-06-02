using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Category.Commands;
using ShopOnline.Hiep.Application.Category.Dtos;
using ShopOnline.Hiep.Application.Category.Queries;

namespace ShopOnline.Hiep.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CategoryController : ApiControllerBase
    {
        [HttpGet]
        public Task<PaginatedList<CategoryDto>> Get([FromQuery] CategoryPagingFilterDto filter)
        {
            return Mediator.Send(new GetCategoryQuery
            {
                Filter = filter
            });
        }

        [HttpGet("{id}")]
        public Task<CategoryDto> GetById([FromRoute] string id)
        {
            return Mediator.Send(new GetCategoryByCategoryCodeQuery
            {
                Id = id
            });
        }

        [HttpPost]
        public Task<ResponseModel<bool>> CreateCategoryAsync([FromBody] CategoryAddDto writeDto)
        {
            return Mediator.Send(new CreateCategoryCommand
            {
                Dto = writeDto
            });
        }

        [HttpPut("{id}")]
        public async Task<ResponseModel<bool>> UpdateCategoryAsync([FromRoute] string id, [FromBody] CategoryUpdateDto writeDto)
        {
            return await Mediator.Send(new UpdateCategoryCommand
            {
                Id = id,
                Dto = writeDto
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel<bool>> DeleteCategoryAsync([FromRoute] string id)
        {
            return Mediator.Send(new DeleteCategoryCommand
            {
                Id = id
            });
        }
    }
}
