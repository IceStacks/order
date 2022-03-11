using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

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

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault();

            if (order is not null)
            {
                throw new InvalidOperationException("Eklenecek sipariş zaten mevcut.");
            }

            order = _mapper.Map<Order>(Model);

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}