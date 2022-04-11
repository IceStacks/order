using AutoMapper;
using System;
using System.Linq;
using Utilities;
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

        public IResult Handle()
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == OrderId);

            if (order is null)
            {
                return new ErrorResult("Güncellenecek sipariş bulunamadı.");
            }

            _mapper.Map(Model, order);
            _context.SaveChanges();

            return new SuccessResult("Sipariş başarıyla güncellendi.");
        }
    }
}
