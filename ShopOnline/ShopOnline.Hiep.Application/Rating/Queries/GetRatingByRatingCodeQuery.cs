using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Rating.Dtos;

namespace ShopOnline.Hiep.Application.Rating.Queries
{
    public class GetRatingByRatingCodeQuery : IRequest<RatingDto>
    {
        public string Id { get; set; } = null!;
    }

    public class GetRatingByRatingCodeQueryHandler : IRequestHandler<GetRatingByRatingCodeQuery, RatingDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRatingByRatingCodeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RatingDto> Handle(GetRatingByRatingCodeQuery request, CancellationToken cancellationToken)
        {
            var rating = await _context.Ratings.AsNoTracking().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            return _mapper.Map<RatingDto>(rating);
        }
    }
}
