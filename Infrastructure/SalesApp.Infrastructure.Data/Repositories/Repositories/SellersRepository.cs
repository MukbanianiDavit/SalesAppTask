using Microsoft.EntityFrameworkCore;
using SalesApp.Infrastructure.Data.Entities;
using SalesApp.Infrastructure.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesApp.Infrastructure.Data.Repositories.Repositories
{
    public class SellersRepository : ISellersRepository
    {
        private readonly SalesAppDbContext _dbContext;

        public SellersRepository(SalesAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddSellerAsync(Seller seller)
        {
            await _dbContext.Set<Seller>().AddAsync(seller);
            var changes = await _dbContext.SaveChangesAsync();
            return (changes > 0);
        }

        public async Task<Seller> GetSellerByIdAsync(Guid sellerId)
        {
            Seller seller = await _dbContext.Set<Seller>().FindAsync(sellerId);
            return seller;
        }

        public async Task<IEnumerable<Seller>> GetAllSellersAsync()
        {
            return await _dbContext.Set<Seller>().ToListAsync();
        }
    }
}
