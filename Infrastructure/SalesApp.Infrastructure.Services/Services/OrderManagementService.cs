using SalesApp.Infrastructure.Data.Entities;
using SalesApp.Infrastructure.Data.Repositories.Interfaces;
using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Models.Models.ResponseModels;
using SalesApp.Infrastructure.Models.Models.ViewModels;
using SalesApp.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Services.Services
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrderManagementService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<BaseResponse> AddOrderAsync(OrderAddRequest orderAddRequest)
        {
            Order order = new Order
            {
                OrderId = Guid.NewGuid(),
                OrderAmount = orderAddRequest.OrderAmount,
                OrderDate = orderAddRequest.OrderDate,
                OrderClientId = orderAddRequest.OrderClientId,
                OrderSellerId = orderAddRequest.OrderSellerId,
                OrderParentId = null
            };

            bool success = await _ordersRepository.AddOrderAsync(order);

            if (success) return new BaseResponse { Success = true, ResponseCode = Models.Enums.ResponseCode.Success };
            else return new BaseResponse { Success = false, ResponseCode = Models.Enums.ResponseCode.CouldNotAddClient };
        }

        public async Task<BaseResponse> AddSuborderAsync(SuborderAddRequest suborderAddRequest)
        {
            Order parentOrder = await _ordersRepository.GetOrderByIdAsync(suborderAddRequest.OrderParentId);

            if (parentOrder == null) return new BaseResponse { Success = false, ResponseCode = Models.Enums.ResponseCode.OrderParentNotFound };

            Order order = new Order
            {
                OrderId = Guid.NewGuid(),
                OrderAmount = suborderAddRequest.OrderAmount,
                OrderDate = suborderAddRequest.OrderDate,
                OrderClientId = parentOrder.OrderClientId,
                OrderSellerId = parentOrder.OrderSellerId,
                OrderParentId = parentOrder.OrderId
            };

            bool success = await _ordersRepository.AddOrderAsync(order);

            if (success) return new BaseResponse { Success = true, ResponseCode = Models.Enums.ResponseCode.Success };
            else return new BaseResponse { Success = false, ResponseCode = Models.Enums.ResponseCode.CouldNotAddOrder };
        }

        public async Task<OrderListingViewModel> GetAllOrdersAsync()
        {
            IEnumerable<Order> orders = await _ordersRepository.GetAllOrdersAsync();
            OrderListingViewModel listingViewModel = new OrderListingViewModel
            {
                Orders = new List<OrderViewModel> { }
            };

            foreach (Order item in orders)
            {
                IEnumerable<Order> subOrders = await _ordersRepository.GetSubOrdersAsync(item.OrderId);
                listingViewModel.Orders.Add(new OrderViewModel
                {
                    OrderId = item.OrderId,
                    OrderDate = item.OrderDate,
                    OrderClientId = item.OrderClientId,
                    OrderSellerId = item.OrderSellerId,
                    OrderSubordersCount = subOrders.Count(),
                    OrderTotalAmount = subOrders.Sum(o => o.OrderAmount) + item.OrderAmount
                });
            }

            return listingViewModel;
        }

        public async Task<OrderViewModel> GetOrderBetweenAsync(DateTime from, DateTime to)
        {
            Order order = await _ordersRepository.GetOrderBetweenAsync(from, to);
            if (order != null)
            {
                IEnumerable<Order> subOrders = (await _ordersRepository.GetSubOrdersAsync(order.OrderId)) ?? new List<Order>();
                OrderViewModel viewModel = new OrderViewModel
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    OrderClientId = order.OrderClientId,
                    OrderSellerId = order.OrderSellerId,
                    OrderSubordersCount = subOrders.Count(),
                    OrderTotalAmount = subOrders.Sum(o => o.OrderAmount) + order.OrderAmount
                };
                return viewModel;
            }
            return null;
        }
    }
}
