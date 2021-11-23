using SalesApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Data.Repositories.Interfaces
{
    /// <summary> Repository to work with <c>Orders</c> </summary>
    public interface IOrdersRepository
    {
        
        /// <summary>
        /// Adds entity to <c>Orders</c> table
        /// </summary>
        /// <param name="order">Entity to add</param>
        /// <returns>Whether operation was successful</returns>
        Task<bool> AddOrderAsync(Order order);

        /// <summary>
        /// Adds range of entities to <c>Orders</c> table
        /// </summary>
        /// <param name="orders">List of entities to add</param>
        /// <returns>Whether operation was successful</returns>
        Task<bool> AddOrderRangeAsync(IEnumerable<Order> orders);

        /// <summary>
        /// Finds <c>Order</c> by unique id
        /// </summary>
        /// <param name="orderId"><c>Order</c> unique id</param>
        /// <returns>Found <c>Client</c> entity or null</returns>
        Task<Order> GetOrderByIdAsync(Guid orderId);
        
        /// <summary>
        /// Finds all the suborders for given <c>Order</c>
        /// </summary>
        /// <param name="orderId">Main <c>Order</c> id</param>
        /// <returns>List of suborder entities or null (if main entity doesn't exist)</returns>
        Task<IEnumerable<Order>> GetSubOrdersAsync(Guid orderId);
        
        /// <summary>
        /// Returns last order between given dates
        /// </summary>
        /// <param name="from">Lower date limit</param>
        /// <param name="to">Upper date limit</param>
        /// <returns>Found <c>Order</c> entity or null</returns>
        Task<Order> GetOrderBetweenAsync(DateTime from, DateTime to);

        /// <summary>
        /// Returns all "main" orders from the <c>Orders</c> table
        /// </summary>
        /// <returns>List of the found orders</returns>
        Task<IEnumerable<Order>> GetAllOrdersAsync();

    }
}
