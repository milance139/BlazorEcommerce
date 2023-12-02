﻿
using System.Security.Claims;

namespace BlazorEcommerce.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context, ICartService cartService, IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductType)
                .Where(o => o.Id == orderId && o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found...";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Products = new List<OrderDetailsProductResponse>()
            };

            order.OrderItems.ForEach(order => orderDetailsResponse.Products.Add(new OrderDetailsProductResponse
            {
                ProductId = order.ProductId,
                Quantity = order.Quantity,
                Title = order.Product.Title,
                ProductType = order.ProductType.Name,
                TotalPrice = order.TotalPrice,
                ImageUrl = order.Product.ImageURL
            }));

            response.Data = orderDetailsResponse; 
            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();

            var orders = await _context.Orders
                .Include(o => o.OrderItems)       
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(order => orderResponse.Add(new OrderOverviewResponse
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Product = order.OrderItems.Count > 1 ? $"{order.OrderItems.First().Product.Title}" +
                                                       $" and {order.OrderItems.Count -1} more items" :
                                                     order.OrderItems.First().Product.Title,
                ProductImageUrl = order.OrderItems.First().Product.ImageURL
            }));

            response.Data = orderResponse;

            return response;

        }

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var products = (await _cartService.GetCartProductsFromDb()).Data;
            decimal totalPrice = 0;

            products.ForEach(product => totalPrice += product.Price * product.Quantity);

            var orderItems = new List<OrderItem>();

            products.ForEach(product => orderItems.Add(new OrderItem
            {
                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity,
            }));

            var order = new Order
            {
                UserId = _authService.GetUserId(),
                OrderItems = orderItems,
                TotalPrice = totalPrice
            };

            _context.Orders.Add(order);

            _context.CartItem.RemoveRange(_context.CartItem
                                            .Where(ci =>ci.UserId == _authService.GetUserId()));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true
            };
        }
    }
}
