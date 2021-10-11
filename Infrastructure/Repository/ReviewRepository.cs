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
    public class ReviewRepository: EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        
        // public override async Task<IEnumerable<Review>> ListAsync(Expression<Func<Review, bool>> filter)
        // {
        //     var favorite = await _dbContext.Reviews.Include(r => r.Movie).Where(filter).ToListAsync();
        //     return favorite;
        // }
    }
}