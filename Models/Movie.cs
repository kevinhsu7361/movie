using System;
using System.Collections.Generic;

#nullable disable

namespace movie.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieContent { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
