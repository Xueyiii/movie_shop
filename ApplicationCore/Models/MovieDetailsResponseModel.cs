using System;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class MovieDetailsResponseModel
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public decimal ?Revenue { get; set; }
        public string Tagline { get; set; }
        public int? RunTime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Overview { get; set; }
        public decimal? Price { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Rating { get; set; }
        
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Cast> Casts { get; set; }
    }
    
}