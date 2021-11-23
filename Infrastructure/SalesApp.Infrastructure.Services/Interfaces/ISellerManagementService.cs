using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Models.Models.ViewModels;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Services.Interfaces
{
    /// <summary> Service to manage sellers </summary>
    public interface ISellerManagementService
    {

        /// <summary>
        /// Adds seller to the database
        /// </summary>
        /// <param name="seller">Model with necessary seller fields</param>
        /// <returns>Response with result code and success status</returns>
        Task<bool> CreateSellerAsync(SellerAddRequest seller);

        /// <summary>
        /// Finds all the sellers registered and constructs hierarchy tree
        /// </summary>
        /// <returns>Tree view of the seller hierarchy</returns>
        Task<SellerTreeViewModel> GetSellers();

    }
}
