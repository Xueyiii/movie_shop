using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;

        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
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

        public async Task<IEnumerable<MovieCardResponseModel>> GetPurchaseMoviesByUser(int id)
        {
            var purchases = await _purchaseRepository.ListAsync(p => p.UserId == id);

            if (purchases !=null)
            {
                return new List<MovieCardResponseModel>();
            }

            var movieCardResponseModel = new List<MovieCardResponseModel>();
            foreach (var purchase in purchases)
            {
                movieCardResponseModel.Add(new MovieCardResponseModel
                {
                    Id = purchase.Movies.Id,
                    PosterUrl = purchase.Movies.PosterUrl,
                    Revenue = purchase.Movies.Revenue,
                    Title = purchase.Movies.Title
                });
            }

            return movieCardResponseModel;
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