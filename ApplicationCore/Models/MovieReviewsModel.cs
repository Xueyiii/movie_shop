using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class MovieReviewsModel
    {
        public int UserId { get; set; }
        public List<ReviewModel> ReviewModels { get; set; }
    }
}