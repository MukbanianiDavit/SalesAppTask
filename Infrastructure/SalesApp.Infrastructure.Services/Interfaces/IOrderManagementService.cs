using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Models.Models.ResponseModels;
using SalesApp.Infrastructure.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Services.Interfaces
{
    /// <summary> Service to manage orders </summary>
    public interface IOrderManagementService
    {

        /// <summary>
        /// Adds "main" order to the database
        /// </summary>
        /// <param name="orderAddRequest">Model with necessary order fields</param>
        /// <returns>Response with result code and success status</returns>
        Task<BaseResponse> AddOrderAsync(OrderAddRequest orderAddRequest);

        /// <summary>
        /// Adds suborder for the "main" order to the database
        /// </summary>
        /// <param name="orderAddRequest">Model with necessary suborder fields</param>
        /// <returns>Response with result code and success status</returns>
        Task<BaseResponse> AddSuborderAsync(SuborderAddRequest suborderAddRequest);
        
        /// <summary>
        /// Returns all the "main" orders registered and their suborder information
        /// </summary>
        /// <returns>Listing view of the orders found</returns>
        Task<OrderListingViewModel> GetAllOrdersAsync();
        
        /// <summary>
        /// Returns the last order between given dates 
        /// </summary>
        /// <param name="from">Lower date limit</param>
        /// <param name="to">Upper date limit</param>
        /// <returns>View of the order found or null (if no such order exists)</returns>
        Task<OrderViewModel> GetOrderBetweenAsync(DateTime from, DateTime to);

    }
}
