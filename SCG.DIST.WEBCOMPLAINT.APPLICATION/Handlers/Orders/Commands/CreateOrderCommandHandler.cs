using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = new Order();
            newOrder.OrderDate = request.OrderDate;
            newOrder.ShippedDate = request.ShippedDate;
            newOrder.ShippedId = request.ShippedId;
            newOrder.CustomerId = request.CustomerId;

            _unitOfWork.OrderRepository.Add(newOrder);
            _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
