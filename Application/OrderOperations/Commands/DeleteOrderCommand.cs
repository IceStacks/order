using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;

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

        public void Handle()
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == OrderId);

            if (order is null)
            {
                throw new InvalidOperationException("Silinecek tedarikçi bulunamadı.");
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}

