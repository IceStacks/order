using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;
using WebApi.Models;

namespace Application.OrderOperations.Commands
{
    public class GetOrdersQuery
    {
        private readonly OrdersDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQuery(OrdersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetOrdersViewModel> Handle() 
        {
            var orders=_context.Orders.OrderBy(x => x.Id ).ToList<Order>();
            var ordersViewModel=_mapper.Map<List<GetOrdersViewModel>>(orders);
            return ordersViewModel;
        }
        
    }
}