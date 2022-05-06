using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenre = new HashSet<MovieGenre>();
        }

        public long IdGenre { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
