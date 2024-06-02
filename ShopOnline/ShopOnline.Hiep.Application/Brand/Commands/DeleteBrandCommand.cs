using MediatR;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Hiep.Application.Brand.Commands
{
    public class DeleteBrandCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
    }

    internal class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteBrandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (brand == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Brand với mã  {request.Id} không tồn tại"
                };
            }

            brand.Status = true;

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }

}
