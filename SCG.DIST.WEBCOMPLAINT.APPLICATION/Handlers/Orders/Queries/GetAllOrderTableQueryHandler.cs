using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Orders;
using MediatR;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Orders.Queries
{
    public class GetAllOrderTableQueryHandler : IRequestHandler<GetAllOrderTableQuery, List<OrderResponseDTO>>
    {
        private IUnitOfWork _unitOfWork;
        public GetAllOrderTableQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<OrderResponseDTO>> Handle(GetAllOrderTableQuery request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.OrderRepository.GetAll();

            var result = ObjectMapper.Mapper.Map<List<OrderResponseDTO>>(query);
            return result;
        }
    }
}
