using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Source -> Target
            CreateMap<OrderCreateDto, Order>();
        }
    }
}
