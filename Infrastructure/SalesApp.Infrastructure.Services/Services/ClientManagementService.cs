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
    public class ClientManagementService : IClientManagementService
    {
        private readonly IClientsRepository _clientsRepository;

        public ClientManagementService(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<BaseResponse> AddClientAsync(ClientAddRequest clientAddRequest)
        {
            Client client = new Client
            {
                ClientId = Guid.NewGuid(),
                ClientFname = clientAddRequest.ClientFname,
                ClientLname = clientAddRequest.ClientLname
            };

            bool success = await _clientsRepository.AddClientAsync(client);

            if (success) return new BaseResponse { Success = true, ResponseCode = Models.Enums.ResponseCode.Success };
            else return new BaseResponse { Success = false, ResponseCode = Models.Enums.ResponseCode.CouldNotAddClient };

        }

        public async Task<ClientListingViewModel> GetAllClientsAsync()
        {
            IEnumerable<Client> clients = await _clientsRepository.GetAllClientsAsync();
            ClientListingViewModel listingViewModel = new ClientListingViewModel
            {
                Clients = clients.Select(c => new ClientViewModel
                {
                    ClientId = c.ClientId,
                    ClientFname = c.ClientFname,
                    ClientLname = c.ClientLname
                }).ToList()
            };
            return listingViewModel;
        }
    }
}
