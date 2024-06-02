using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Rating.Commands;
using ShopOnline.Hiep.Application.Rating.Dtos;
using ShopOnline.Hiep.Application.Rating.Queries;

namespace ShopOnline.Hiep.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class RatingController : ApiControllerBase
    {
        [HttpGet]
        public Task<PaginatedList<RatingDto>> Get([FromQuery] RatingPagingFilterDto filter)
        {
            return Mediator.Send(new GetRatingQuery
            {
                Filter = filter
            });
        }

        [HttpGet("{id}")]
        public Task<RatingDto> GetById([FromRoute] string id)
        {
            return Mediator.Send(new GetRatingByRatingCodeQuery
            {
                Id = id
            });
        }

        [HttpPost]
        public Task<ResponseModel<bool>> CreateRatingAsync([FromBody] RatingAddDto writeDto)
        {
            return Mediator.Send(new CreateRatingCommand
            {
                Dto = writeDto
            });
        }

        [HttpPut("{id}")]
        public async Task<ResponseModel<bool>> UpdateRatingAsync([FromRoute] string id, [FromBody] RatingUpdateDto writeDto)
        {
            return await Mediator.Send(new UpdateRatingCommand
            {
                Id = id,
                Dto = writeDto
            });
        }

        [HttpDelete("{id}")]
        public Task<ResponseModel<bool>> DeleteRatingAsync([FromRoute] string id)
        {
            return Mediator.Send(new DeleteRatingCommand
            {
                Id = id
            });
        }
    }
}
