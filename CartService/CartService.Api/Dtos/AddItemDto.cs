using System;

namespace CartService.Api.Dtos;

public record AddItemDto(Guid ProductId, int Quantity, decimal Price);