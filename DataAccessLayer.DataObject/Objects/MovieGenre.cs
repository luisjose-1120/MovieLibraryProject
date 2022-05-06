using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class MovieGenre
    {
        public long IdMovie { get; set; }
        public long IdGenre { get; set; }

        public virtual Genre IdGenreNavigation { get; set; }
        public virtual Movie IdMovieNavigation { get; set; }
    }
}
