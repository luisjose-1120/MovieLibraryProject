using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.BE.Models
{
    public  class Movie
    {
       

        public long IdMovie { get; set; }
        public long IdDirector { get; set; }
        public long IdProduction { get; set; }
        public string MovieName { get; set; }
        public string MovieSynopsis { get; set; }
        public int MovieYear { get; set; }
        public byte[] MovieCartel { get; set; }

        public virtual Director IdDirectorNavigation { get; set; }
        public virtual Production IdProductionNavigation { get; set; }
    }
}
