using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Brand.Dtos;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;

namespace ShopOnline.Hiep.Application.Brand.Commands
{
    public class UpdateBrandCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
        public BrandUpdateDto Dto { get; set; } = null!;
    }

    internal class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<bool>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var ratingCode = request.Id ?? string.Empty;
            var rating = await _context.Brands.FirstOrDefaultAsync(x => x.Id == ratingCode);

            if (rating == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Brand với mã {ratingCode} không tồn tại"
                };
            }

            _mapper.Map(request.Dto, rating);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }

}
