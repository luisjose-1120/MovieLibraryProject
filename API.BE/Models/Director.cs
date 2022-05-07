using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.BE.Models
{
    public  class Director
    {
       

        public long IdDirector { get; set; }
        public string DirectorName { get; set; }
        public string DirectorLastname { get; set; }
        public int DirectorAge { get; set; }

    }
}
