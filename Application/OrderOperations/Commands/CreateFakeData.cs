using AutoMapper;
using System;
using System.Linq;
using Utilities;
using WebApi.DbOperations;
using WebApi.Models;
using WebApi.Models.WebApi.Models;

namespace WebApi.Application.OrderOperations.Commands
{
    public class CreateFakeData
    {
        public Order Model { get; set; }

        private readonly OrdersDbContext _context;



        public CreateFakeData(OrdersDbContext context)
        {
            _context = context;
        }

        public IResult Handle()
        {
            _context.Orders.Add(Model);
            _context.SaveChanges();

            return new SuccessResult("Sipariş başarıyla eklendi.");

        }
    }
}