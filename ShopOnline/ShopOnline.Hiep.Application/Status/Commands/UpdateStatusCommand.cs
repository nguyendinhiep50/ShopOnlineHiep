using AutoMapper;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Hiep.Application.Status.Dtos;

namespace ShopOnline.Hiep.Application.Status.Commands
{
    public class UpdateStatusCommand : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; } = null!;
        public StatusUpdateDto Dto { get; set; } = null!;
    }

    internal class UpdateAccountGroupCommandHandler : IRequestHandler<UpdateStatusCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAccountGroupCommandHandler(IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<bool>> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var statusId = request.Id ?? string.Empty;
            var status = await _context.statuses.FirstOrDefaultAsync(x => x.Id == statusId);

            if (status == null)
            {
                return new ResponseModel<bool>
                {
                    IsSuccess = false,
                    Message = $"Nhóm tài khoản với mã nhóm {statusId} không tồn tại"
                };
            }

            _mapper.Map(request.Dto, status);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<bool>
            {
                IsSuccess = true
            };
        }
    }
}
