using AutoMapper;
using System;
using System.Linq;
using Utilities;
using WebApi.DbOperations;
using WebApi.Models;
using WebApi.Models.WebApi.Models;

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
            var Order = _context.Orders.SingleOrDefault(Order => Order.UserId == Model.UserId );

            if (Order is not null)
            {
                return new ErrorResult("Bu kullanıcıya ait sipariş mevcuttur.");
            }

            Order = _mapper.Map<Order>(Model);

            _context.Orders.Add(Order);
            _context.SaveChanges();

            return new SuccessResult("Sipariş başarıyla eklendi.");

        }
    }
}