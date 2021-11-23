using SalesApp.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Data.Repositories.Interfaces
{
    /// <summary> Repository to work with <c>Clients</c> </summary>
    public interface IClientsRepository
    {

        /// <summary>
        /// Adds entity to <c>Clients</c> table
        /// </summary>
        /// <param name="client">Entity to add</param>
        /// <returns>Whether operation was successful</returns>
        Task<bool> AddClientAsync(Client client);


        /// <summary>
        /// Finds <c>Client</c> by unique id
        /// </summary>
        /// <param name="client"><c>Client</c> unique id</param>
        /// <returns>Found <c>Client</c> entity or null</returns>
        Task<Client> GetClientByIdAsync(Guid clientId);
        
        /// <summary>
        /// Returns all clients registered
        /// </summary>
        /// <returns>List of registered clients</returns>
        Task<IEnumerable<Client>> GetAllClientsAsync();

    }
}
