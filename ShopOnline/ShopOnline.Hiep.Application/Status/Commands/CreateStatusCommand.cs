using AutoMapper;
using ShopOnline.Hiep.Application.Common.Interfaces;
using ShopOnline.Hiep.Application.Common.Models;
using MediatR;
using ShopOnline.Hiep.Domain.Entities;
using ShopOnline.Hiep.Application.Status.Dtos;
using ShopOnline.Hiep.Application.Status.Queries;

namespace ShopOnline.Hiep.Application.Status.Commands
{
    public class CreateStatusCommand : IRequest<ResponseModel<StatusDto>>
    {
        public StatusAddDto Dto { get; set; } = null!;
    }

    internal class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, ResponseModel<StatusDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateStatusCommandHandler(IApplicationDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel<StatusDto>> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = _mapper.Map<Statuses>(request.Dto!);

            var existedStatusCode = await _mediator.Send(new CheckStatusCodeExistedQuery
            {
                Id = status.Id
            });

            if (existedStatusCode)
            {
                return new ResponseModel<StatusDto>
                {
                    IsSuccess = false,
                    Message = $"Nhóm tài khoản với mã nhóm {status.Id} đã tồn tại"
                };
            }

            await _context.statuses.AddAsync(status);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel<StatusDto>
            {
                IsSuccess = true,
                Data = _mapper.Map<StatusDto>(status)
            };
        }
    }
}
