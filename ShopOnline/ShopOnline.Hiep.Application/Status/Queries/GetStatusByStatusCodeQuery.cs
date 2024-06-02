using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Status.Dtos;

namespace ShopOnline.Hiep.Application.Status.Queries
{

    public class GetStatusByStatusCodeQuery : IRequest<StatusDto>
    {
        public string Id { get; set; } = null!;
    }

    public class GetAccountGroupByAccountGroupCodeQueryHandler : IRequestHandler<GetStatusByStatusCodeQuery, StatusDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountGroupByAccountGroupCodeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Handle(GetStatusByStatusCodeQuery request, CancellationToken cancellationToken)
        {
            var accountGroup = await _context.statuses.AsNoTracking().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            return _mapper.Map<StatusDto>(accountGroup);
        }
    }
}
