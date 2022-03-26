using AutoMapper;
using System;
using System.Linq;
using Utilities;
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

        public IResult Handle()
        {
            Order Order = _context.Orders.FirstOrDefault(x => x.Id == OrderId);

            if (Order is null)
            {
                return new ErrorResult("Silinecek tedarikçi bulunamadı.");
            }

            _context.Orders.Remove(Order);
            _context.SaveChanges();

            return new SuccessResult("Tedarikçi başarıyla silindi.");
        }
    }
}