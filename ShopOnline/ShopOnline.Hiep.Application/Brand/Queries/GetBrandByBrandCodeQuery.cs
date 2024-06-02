using AutoMapper;
using MediatR;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Brand.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Hiep.Application.Brand.Queries
{
    public class GetBrandByBrandCodeQuery : IRequest<BrandDto>
    {
        public string Id { get; set; } = null!;
    }

    public class GetBrandByBrandCodeQueryHandler : IRequestHandler<GetBrandByBrandCodeQuery, BrandDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBrandByBrandCodeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BrandDto> Handle(GetBrandByBrandCodeQuery request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.AsNoTracking().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            return _mapper.Map<BrandDto>(brand);
        }
    }

}
