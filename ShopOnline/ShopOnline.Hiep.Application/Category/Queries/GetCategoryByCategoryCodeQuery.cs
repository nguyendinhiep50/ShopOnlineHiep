using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Category.Dtos;
using ShopOnline.Hiep.Application.Common.Interfaces;

namespace ShopOnline.Hiep.Application.Category.Queries
{
    public class GetCategoryByCategoryCodeQuery : IRequest<CategoryDto>
    {
        public string Id { get; set; } = null!;
    }

    public class GetCategoryByCategoryCodeQueryHandler : IRequestHandler<GetCategoryByCategoryCodeQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByCategoryCodeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByCategoryCodeQuery request, CancellationToken cancellationToken)
        {
            var rating = await _context.Categories.AsNoTracking().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            return _mapper.Map<CategoryDto>(rating);
        }
    }

}
