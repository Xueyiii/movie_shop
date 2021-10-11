using System.Collections;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class PurchaseResponseModel : IEnumerable
    {
        public int UserId { get; set; }
        public int TotalMoviesPurchased { get; set; }
        public List<MovieCardResponseModel> PurchasedMovies { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}