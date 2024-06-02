using MediatR;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Hiep.Application.Category.Commands
{
    public class DeleteCategoryCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
    }
    internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Category với mã  {request.Id} không tồn tại"
                };
            }

            category.Status = true;

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }

}
