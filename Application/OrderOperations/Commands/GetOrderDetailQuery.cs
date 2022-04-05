using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Models;
using Utilities;
using AutoMapper;

namespace WebApi.Application.OrderOperations.Commands
{
    public class GetOrderDetailQuery
    {
        public int OrderId {get; set; }
        
        private readonly OrdersDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderDetailQuery(OrdersDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public IDataResult<GetOrderDetailViewModel> Handle()
        {
            var order= _context.Orders.Where(x => x.Id == OrderId).SingleOrDefault();

            if(order is null)
            {
                return new ErrorDataResult<GetOrderDetailViewModel>("Aranan sipariş bulunamadı.");
            }
            GetOrderDetailViewModel orderDetailViewModel = _mapper.Map<GetOrderDetailViewModel>(order);
            return new SuccessDataResult<GetOrderDetailViewModel>(orderDetailViewModel, "Sipariş bigileri görüntülendi.");

        }
    }
}
