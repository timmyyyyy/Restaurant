using MediatR;
using Restaurant.Application.Dtos;

namespace Restaurant.Application.Queries;

public record GetMenuByRestaurantIdQuery(Guid RestaurantId) : IRequest<MenuDto?>;
