using AutoMapper;
using CartService.Api.Dtos;
using CartService.Domain;

namespace CartService.Api.Mapper;

public class CartMappingProfile : Profile
{
    public CartMappingProfile()
    {
        CreateMap<Cart, CartDto>();
        CreateMap<CartItem, CartItemDto>();
        CreateMap<AddItemDto, CartItem>();
    }
}