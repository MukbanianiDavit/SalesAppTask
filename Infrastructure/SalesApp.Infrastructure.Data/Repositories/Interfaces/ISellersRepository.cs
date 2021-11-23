using SalesApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Data.Repositories.Interfaces
{
    /// <summary> Repository to work with <c>Sellers</c> </summary>
    public interface ISellersRepository
    {
        /// <summary>
        /// Adds entity to <c>Seller</c> table
        /// </summary>
        /// <param name="seller">Entity to add</param>
        /// <returns>Whether operation was successful</returns>
        Task<bool> AddSellerAsync(Seller seller);

        /// <summary>
        /// Finds <c>Seller</c> by unique id
        /// </summary>
        /// <param name="sellerId"><c>Seller</c> unique id</param>
        /// <returns>Found <c>Seller</c> entity or null</returns>
        Task<Seller> GetSellerByIdAsync(Guid sellerId);

        /// <summary>
        /// Returns all sellers registered
        /// </summary>
        /// <returns>List of registered sellers</returns>
        Task<IEnumerable<Seller>> GetAllSellersAsync();

    }
}
