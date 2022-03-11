using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.OrderOperations.Commands
{
    public class GetOrderDetailQuery
    {
        public int OrderId {get; set; }
        
        private readonly OrdersDbContext _context;
        
        public GetOrderDetailQuery(OrdersDbContext context, AutoMapper.IMapper _mapper) 
        {
            _context = context;
        }
        public Order Handle()
        {
            var order= _context.Orders.Where(x => x.Id == OrderId).SingleOrDefault();

            if(order is null)
            {
                throw new InvalidOperationException("Aranan Sipariş Bulunamadı.");
            }

            return order;

        }
    }
}
