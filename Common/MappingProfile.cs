using AutoMapper;
using WebApi.Models;

namespace WebApi.Common
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Order,GetOrdersViewModel>();
             CreateMap<Order, GetOrderDetailViewModel>();
            CreateMap<CreateOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => !srcMember.Equals("")));
        }
    }
}
