using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;


        public UserController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;

        }

        [Authorize]
        [Route("purchases")]
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            var userId = _currentUserService.UserId;
            var purchases = await _userService.GetPurchaseMoviesByUser(userId);
            // call the User Service to get movies purchased by user, and send the data to the view, and use the existing MovieCard partial View
            return Ok(purchases);
        }
        
        [Authorize]
        [Route("favorites")]
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUserService.UserId;
            var favorites = await _userService.GetFavoriteMoviesByUser(userId);
            // call the User Service to get movies Favorited by user, and send the data to the view, and use the existing MovieCard partial View

            return Ok(favorites);
        }
        
        [Authorize]
        [Route("Reviews")]
        [HttpGet]
        public async Task<ActionResult> Reviews()
        {
            var userId = _currentUserService.UserId;
            var userMovies = await _userService.GetReviewsByUser(userId);
            return Ok(userMovies);
        }
        
        [Authorize]
        [Route("Purchase")]
        [HttpPost]
        public async Task<ActionResult> CreatePurchase([FromBody] PurchaseRequestModel purchaseRequestModel)
        {
            var purchasedStatus =
                await _userService.PurchaseMovie(purchaseRequestModel, _currentUserService.UserId);
            return Ok(new { purchased = purchasedStatus });
        }
        
        [Authorize]
        [Route("favorite")]
        [HttpPost]
        public async Task<ActionResult> CreatePurchase([FromBody] FavoriteRequestModel favoriteRequestModel)
        {
            var purchasedStatus =
                await _userService.AddFavoriteMovie(favoriteRequestModel, _currentUserService.UserId);
            return Ok(new { purchased = purchasedStatus });
        }
        
        [Authorize]
        [Route("unfavorite")]
        [HttpPost]
        public async Task<ActionResult> DeleteFavorite([FromBody] FavoriteRequestModel favoriteRequestModel)
        {
            await _userService.UnfavoriteMovie(favoriteRequestModel);
            return Ok();
        }
        
        [Authorize]
        [Route("review")]
        [HttpPost]
        public async Task<ActionResult> CreateReview([FromBody] ReviewModel reviewModel)
        {
            var reviewStatus = await _userService.AddMovieReview(reviewModel, _currentUserService.UserId);
            return Ok(reviewStatus);
        }
        
        [Authorize]
        [Route("review")]
        [HttpPut]
        public async Task<ActionResult> UpdateReview([FromBody] ReviewModel reviewModel)
        {
            await _userService.UpdateMovieReview(reviewModel);
            return Ok();
        }
        
        [Authorize]
        [Route("user/{userId:int}/movie/{movieId:int}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteReview(int userId, int movieId)
        {
            await _userService.DeleteMovieReview(userId, movieId);
            return NoContent();
        }
        
    }
}