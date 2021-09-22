using System;
namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public decimal Revenue { get; set; }
        public String PosterUrl { get; set; }
    }
}
