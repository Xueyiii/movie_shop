using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMovieService _movieService;
        private readonly IReviewRepository _reviewRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository,
            IMovieService movieService, IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _movieService = movieService;
            _reviewRepository = reviewRepository;
        }
        
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel)
        {
            // first check if the email user entered exists in the database
            // if yes, throw an throw exception or send a message saying email exists
            var user = await _userRepository.GetUserByEmail(requestModel.Email);

            if (user !=null)
            {
                // email exits in the database
                throw new Exception($"Email {requestModel.Email} exists, please try to login");
            }
            // continue
            // create a random salt and hash the password with the salt

            var salt = GenerateSalt();
            var hashedPassword = GenerateHashedPassword(requestModel.Password, salt);
            
            // create user entity object and call user repo to save
            var newUser = new User
            {
                Email = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                DateOfBirth = requestModel.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.AddAsync(newUser);

            var userRegisterResponseModel = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return userRegisterResponseModel;

        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            // get the user info from database by email
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                // we dont have the email in the database
                return null;
            }
            
            // we need to hash the user entered password along with salt from database.
            var hashedPassword = GenerateHashedPassword(password, user.Salt);

            if (hashedPassword == user.HashedPassword)
            {
                // user entered correct password
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth
                };
                return userLoginResponseModel;
            }

            return null;

        }

        public async Task<PurchaseResponseModel> GetPurchaseMoviesByUser(int id)
        {
            var totalPurchasesCount = await _purchaseRepository.GetCountAsync(purchase => purchase.UserId == id);
            var purchasedMovies = await _purchaseRepository.GetPurchaseMoviesByUserId(id);

            var movies = new PurchaseResponseModel
            {
                UserId = id,
                PurchasedMovies = new List<MovieCardResponseModel>(),
                TotalMoviesPurchased = totalPurchasesCount
            };
            foreach (var purchase in purchasedMovies)
                movies.PurchasedMovies.Add(new MovieCardResponseModel
                {
                    Id = purchase.MovieId,
                    Title = purchase.Movies.Title,
                    PosterUrl = purchase.Movies.PosterUrl,
                    Revenue = purchase.Movies.Revenue,
                    ReleaseDate = purchase.Movies.ReleaseDate.GetValueOrDefault()
                });

            return movies;
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetFavoriteMoviesByUser(int id)
        {
            var favorites = await _favoriteRepository.ListAsync(f => f.UserId == id);

            if (favorites !=null)
            {
                return new List<MovieCardResponseModel>();
            }

            var movieCardResponseModel = new List<MovieCardResponseModel>();
            foreach (var favorite in favorites)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel
                {
                    Id = favorite.Movie.Id,
                    PosterUrl = favorite.Movie.PosterUrl,
                    Revenue = favorite.Movie.Revenue,
                    Title = favorite.Movie.Title
                });
            }

            return movieCardResponseModel;
        }

        public async Task<IEnumerable<PurchaseRequestModel>> GetPurchaseDetailsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieReviewsModel> GetReviewsByUser(int id)
        {
            var reviews = await _userRepository.GetReviewsByUser(id);
            var movieReviewsModel = new MovieReviewsModel()
            {
                UserId = id, 
                ReviewModels = new List<ReviewModel>()
            };
            movieReviewsModel.ReviewModels = reviews.Select(r => new ReviewModel()
            {
                UserId = id, MovieId = r.MovieId, Rating = r.Rating, ReviewText = r.ReviewText
            }).ToList();
            return movieReviewsModel;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequestModel, int userId)
        {
            if (await IsMoviePurchased(purchaseRequestModel, userId))
            {
                throw new Exception("Movie Already Purchased");
            }
            // get movie price
            var movie = await _movieService.GetMovieById(purchaseRequestModel.MovieId);
            var purchase = new Purchase
            {
                MovieId = purchaseRequestModel.MovieId, UserId = purchaseRequestModel.UserId,
                PurchaseNumber = Guid.NewGuid(), PurchaseDateTime = DateTime.Now,
                TotalPrice = movie.Price.GetValueOrDefault()
            };
            var createPurchase = await _purchaseRepository.AddAsync(purchase);
            return createPurchase.Id > 0;
        }
        
        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequestModel, int userId)
        {
            return await _purchaseRepository.GetExistsAsync(p =>
                p.UserId == userId && p.MovieId == purchaseRequestModel.MovieId);
        }

        public async Task<bool> AddFavoriteMovie(FavoriteRequestModel favoriteRequestModel, int userId)
        {
            if (await IsFavourite(favoriteRequestModel.UserId, favoriteRequestModel.MovieId))
            {
                throw new Exception("Movie Already Favourited");
            }

            var favourite = new Favorite
            {
                MovieId = favoriteRequestModel.MovieId, UserId = favoriteRequestModel.UserId
            };
            var addFavourite = await _favoriteRepository.AddAsync(favourite);
            return addFavourite.Id > 0;
        }

        public async Task UnfavoriteMovie(FavoriteRequestModel favoriteRequestModel)
        {
            var unfavorite = await _favoriteRepository.ListAsync(f => f.UserId == favoriteRequestModel.UserId
                                                                      && f.MovieId == favoriteRequestModel.MovieId);
            await _favoriteRepository.DeleteAsync(unfavorite.First());
        }

        public async Task<bool> IsFavourite(int userId, int movieId)
        {
            return await _favoriteRepository.GetExistsAsync(f => f.UserId == userId && f.MovieId == movieId);
        }

        public async Task<bool> AddMovieReview(ReviewModel reviewModel, int userId)
        {
            var review = new Review
            {
                UserId = reviewModel.UserId, MovieId = reviewModel.MovieId,
                Rating = reviewModel.Rating, ReviewText = reviewModel.ReviewText,
            };
            var addReview = _reviewRepository.AddAsync(review);
            return addReview.Id > 0;
        }

        public async Task UpdateMovieReview(ReviewModel reviewModel)
        {
            var review = new Review
            {
                UserId = reviewModel.UserId, MovieId = reviewModel.MovieId,
                Rating = reviewModel.Rating, ReviewText = reviewModel.ReviewText,
            };
            await _reviewRepository.UpdateAsync(review);
        }
        
        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var delete = await _reviewRepository.ListAsync(r => r.MovieId == movieId && 
                                                                r.UserId == userId);
            await _reviewRepository.DeleteAsync(delete.First());
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("No User Found!");
            }

            var userResponseModel = new UserRegisterResponseModel
            {
                Id = user.Id, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName
            };
            return userResponseModel;
        }


        private string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
           
            return Convert.ToBase64String(randomBytes);
        }

        private string GenerateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        
    }
}