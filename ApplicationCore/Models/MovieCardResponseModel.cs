using System;
namespace ApplicationCore.Models
{
    public class MovieCardResponseModel
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public decimal? Revenue { get; set; }
    }
}