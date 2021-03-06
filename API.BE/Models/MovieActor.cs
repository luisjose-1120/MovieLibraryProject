using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.BE.Models
{
    public  class MovieActor
    {
        public long IdMovieActor { get; set; }
        public long IdMovie { get; set; }
        public long IdActor { get; set; }
        public string MovieRole { get; set; }

        public virtual Actor IdActorNavigation { get; set; }
        public virtual Movie IdMovieNavigation { get; set; }
    }
}
