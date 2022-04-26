using AutoMapper;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.ReadDtos;

namespace WebAPI.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Source -> Target
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrdererCreateDto, Orderer>();
            CreateMap<PaymentCreateDto, Payment>();
            
            CreateMap<Order, OrderReadDto>();
            CreateMap<Orderer, OrdererReadDto>();
            CreateMap<Payment, PaymentReadDto>();
            CreateMap<Driver, DriverReadDto>();
            CreateMap<Passenger, PassengerReadDto>();
            CreateMap<User, UserReadDto>();
        }
    }
}
