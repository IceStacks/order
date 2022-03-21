using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;
using Utilities;

namespace WebApi.Application.OrderOperations.Commands
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model { get; set; }

        private readonly OrdersDbContext _context;
        
        private readonly IMapper _mapper;


        public CreateOrderCommand(OrdersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public IResult Handle()
        {
            var order = _context.Orders.SingleOrDefault();

            if (order is not null)
            {
                return new ErrorResult("Bu sipariş daha önce kayıt edilmiş.");
            }

            order = _mapper.Map<Order>(Model);

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
