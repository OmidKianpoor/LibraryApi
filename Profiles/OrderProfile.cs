using AutoMapper;
using LibraryApi.Dtos;
using LibraryApi.Models;

namespace LibraryApi.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderDto>();
            CreateMap<OrderItem,OrderItemDto>();
        }
    }
}
