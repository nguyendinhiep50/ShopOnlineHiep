using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Hiep.Application.Status.Commands
{
    public class DeleteStatusCommand : IRequest<ResponseModel<bool>>
    {
        public string GroupCode { get; set; } = null!;
    }

    internal class DeleteAccountGroupCommandHandler : IRequestHandler<DeleteStatusCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAccountGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _context.statuses.FirstOrDefaultAsync(x => x.Id == request.GroupCode);

            if (status == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Nhóm tài khoản với mã nhóm {request.GroupCode} không tồn tại"
                };
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
