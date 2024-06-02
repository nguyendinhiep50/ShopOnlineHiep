using AutoMapper;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using ShopOnline.Hiep.Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Status.Dtos;
using ShopOnline.Hiep.Domain.Entities;

namespace ShopOnline.Hiep.Application.AccountGroups.Queries
{
    public class GetStatusQuery : IRequest<PaginatedList<StatusDto>>
    {
        public StatusPagingFilterDto Filter { get; set; } = null!;
    }

    public class GetAccountGroupsQueryHandler : IRequestHandler<GetStatusQuery, PaginatedList<StatusDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountGroupsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<StatusDto>> Handle(GetStatusQuery request, CancellationToken cancellationToken)
        {
            var filter = request.Filter;
            var query = _context.statuses.AsNoTracking();

            var searchText = filter?.SearchText?.Trim() ?? "";
            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => EF.Functions.Like(x.Id!, "%" + searchText + "%")
                                         || EF.Functions.Like(x.Display!, "%" + searchText + "%")
                                        );
            }


            return await query.ToPagingAsync<Statuses, StatusDto>(filter!, _mapper);
        }
    }
}
