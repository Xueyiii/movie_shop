using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    // we use data annotations for changing our Database constrict
    // Fluent API also to put constraints on the database, more powerful
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }
        
        [MaxLength(64)]
        public string Name { get; set; }
        
        public ICollection<MovieGenre> Movies { get; set; }
    }
}