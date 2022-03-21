using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;
using Utilities;

namespace WebApi.Application.OrderOperations.Commands
{
    public class DeleteOrderCommand
    {
        public int OrderId { get; set; }

        private readonly OrdersDbContext _context;

        public DeleteOrderCommand(OrdersDbContext context)
        {
            _context = context;
        }

        public IResult Handle()
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == OrderId);

            if (order is null)
            {
                return new ErrorResult("Silinecek sipariş bulunamadı.");
            }
        }

        _context.Orders.Remove(order);
            _context.SaveChanges();

            return new SuccessResult("sipariş başarıyla silindi.");
    }
}
}

