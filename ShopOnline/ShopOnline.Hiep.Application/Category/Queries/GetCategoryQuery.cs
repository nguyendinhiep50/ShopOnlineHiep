using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Category.Dtos;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Extensions;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.Category.Queries
{
    public class GetCategoryQuery : IRequest<PaginatedList<CategoryDto>>
    {
        public CategoryPagingFilterDto Filter { get; set; } = null!;
    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, PaginatedList<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
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

            return await query.ToPagingAsync<Categories, CategoryDto>(filter!, _mapper);
        }
    }

}
