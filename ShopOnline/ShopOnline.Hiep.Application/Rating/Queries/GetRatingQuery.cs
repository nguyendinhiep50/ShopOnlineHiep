using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Extensions;
using ShopOnline.Hiep.Application.Rating.Dtos;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Rating.Queries
{
    public class GetRatingQuery : IRequest<PaginatedList<RatingDto>>
    {
        public RatingPagingFilterDto Filter { get; set; } = null!;
    }

    public class GetRatingQueryHandler : IRequestHandler<GetRatingQuery, PaginatedList<RatingDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRatingQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<RatingDto>> Handle(GetRatingQuery request, CancellationToken cancellationToken)
        {
            var filter = request.Filter;
            var query = _context.Categories.AsNoTracking();

            var searchText = filter?.SearchText?.Trim() ?? "";
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => EF.Functions.Like(x.Id!, "%" + searchText + "%")
                                         || EF.Functions.Like(x.Name!, "%" + searchText + "%")
                                        );
            }

            return await query.ToPagingAsync<Categories, RatingDto>(filter!, _mapper);
        }
    }

}
