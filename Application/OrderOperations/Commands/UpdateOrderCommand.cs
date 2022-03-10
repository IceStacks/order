using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

namespace WebApi.Application.OrderOperations.Commands
{
    public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId { get; set; }

        private readonly OrdersDbContext _context;

        private readonly IMapper _mapper;


        public UpdateOrderCommand(OrdersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(object order)
        {
            Order supplier = _context.Orders.FirstOrDefault(x => x.Id == OrderId);

            if (order is null)
            {
                throw new InvalidOperationException("Güncellenecek sipariş bulunamadı.");
            }

            _mapper.Map(Model, supplier);
            _context.SaveChanges();
        }
    }
}