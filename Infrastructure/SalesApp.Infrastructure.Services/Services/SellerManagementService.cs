using SalesApp.Infrastructure.Data.Entities;
using SalesApp.Infrastructure.Data.Repositories.Interfaces;
using SalesApp.Infrastructure.Models.Models.RequestModels;
using SalesApp.Infrastructure.Models.Models.ViewModels;
using SalesApp.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Services.Services
{
    public class SellerManagementService : ISellerManagementService
    {
        private readonly ISellersRepository _sellersRepository;

        public SellerManagementService(ISellersRepository sellersRepository)
        {
            _sellersRepository = sellersRepository;
        }

        public async Task<bool> CreateSellerAsync(SellerAddRequest seller)
        {
            if (seller.SellerBossId.HasValue)
            {
                if ((await _sellersRepository.GetSellerByIdAsync(seller.SellerBossId.Value)) == null)
                    return false;
            }

            var result = await _sellersRepository.AddSellerAsync(new Seller
            {
                SellerBossId = seller.SellerBossId,
                SellerFname = seller.SellerFname,
                SellerLname = seller.SellerLname
            });

            return result;
        }

        public async Task<SellerTreeViewModel> GetSellers()
        {
            var allSellers = await _sellersRepository.GetAllSellersAsync();
            var treeView = new SellerTreeViewModel { Nodes = GetEmployees(allSellers).ToList() };

            return treeView;
        }

        // to perform recursive employee search for the "self employed" seller given
        private IEnumerable<SellerTreeNodeViewModel> GetEmployees(IEnumerable<Seller> sellers, Guid? sellerId = null)
        {
            return sellers.Where(i => i.SellerBossId == (sellerId.HasValue ? sellerId : i.SellerId) && i.SellerId != sellerId)
                .Select(e => new SellerTreeNodeViewModel
                {
                    SellerId = e.SellerId,
                    SellerFname = e.SellerFname,
                    SellerLname = e.SellerLname,
                    Employees = GetEmployees(sellers, e.SellerId).ToList()
                });
        }

    }
}
