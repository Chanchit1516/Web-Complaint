﻿using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Orders.Queries
{
    public class GetAllOrderTableQuery : IRequest<List<OrderResponseDTO>>
    {

    }
}
