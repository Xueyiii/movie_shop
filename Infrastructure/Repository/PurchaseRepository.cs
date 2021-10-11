using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PurchaseRepository: EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Purchase>> ListAsync(Expression<Func<Purchase, bool>> filter)
        {
            var purchases = await _dbContext.Purchases.Include(p => p.Movies).Where(filter).ToListAsync();
            return purchases;
        }

        public async Task<IEnumerable<Purchase>> GetPurchaseMoviesByUserId(int userId, int pageSize = 30, int pageIndex = 1)
        {
            var purchases = await _dbContext.Purchases.Include(p=> p.Movies).
                Where(p=> p.UserId == userId)
                .OrderByDescending(p => p.PurchaseDateTime).
                Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }
    }
}