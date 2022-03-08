using AutoMapper;
using WebApi.Models;

namespace WebApi.Common
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Order,GetOrdersViewModel>();
        }
    }
}
