using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Category.Dtos;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;

namespace ShopOnline.Hiep.Application.Category.Commands
{
    public class UpdateCategoryCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
        public CategoryUpdateDto Dto { get; set; } = null!;
    }
    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var ratingCode = request.Id ?? string.Empty;
            var rating = await _context.Categories.FirstOrDefaultAsync(x => x.Id == ratingCode);

            if (rating == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Tài khoản với mã {ratingCode} không tồn tại"
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
