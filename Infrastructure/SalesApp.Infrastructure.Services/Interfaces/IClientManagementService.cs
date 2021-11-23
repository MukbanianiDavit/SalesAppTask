using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Models.Models.ResponseModels;
using SalesApp.Infrastructure.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Services.Interfaces
{
    /// <summary> Service to manage clients </summary>
    public interface IClientManagementService
    {

        /// <summary>
        /// Adds client to the database
        /// </summary>
        /// <param name="clientAddRequest">Model with necessary client fields</param>
        /// <returns>Response with result code and success status</returns>
        Task<BaseResponse> AddClientAsync(ClientAddRequest clientAddRequest);

        /// <summary>
        /// Returns all the clients registered
        /// </summary>
        /// <returns>Listing view of the clients found</returns>
        Task<ClientListingViewModel> GetAllClientsAsync();

    }
}
