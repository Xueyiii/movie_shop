using System;
using System.Collections.Generic;
// using System.Threading.Tasks;
// using ApplicationCore.Entities;
// using ApplicationCore.Models;
// using ApplicationCore.RepositoryInterfaces;
// using ApplicationCore.ServiceInterfaces;
//
// namespace Infrastructure.Services
// {
//     public class PurchaseService:IPurchaseService
//     {
//         private readonly IPurchaseRepository _purchaseRepository;
//
//         public PurchaseService(IPurchaseRepository purchaseRepository)
//         {
//             _purchaseRepository = purchaseRepository;
//         }
//         public async Task<IEnumerable<MovieCardResponseModel>> GetPurchaseMoviesByUserId(int id)
//         {
//             var purchases = await _purchaseRepository.ListAsync(p => p.UserId == id);
//
//             if (purchases !=null)
//             {
//                 throw new Exception("No purchase movies!");
//             }
//
//             var movieCardResponseModel = new List<MovieCardResponseModel>();
//             foreach (var purchase in purchases)
//             {
//                 movieCardResponseModel.Add(new MovieCardResponseModel
//                 {
//                     Id = purchase.Movies.Id,
//                     PosterUrl = purchase.Movies.PosterUrl,
//                     Revenue = purchase.Movies.Revenue,
//                     Title = purchase.Movies.Title
//                 });
//             }
//
//             return movieCardResponseModel;
//         }
//     }
// }