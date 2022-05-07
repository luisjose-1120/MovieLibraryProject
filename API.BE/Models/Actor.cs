using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.BE.Models
{
    public  class Actor
    {
       

        public long IdActor { get; set; }
        public string ActorName { get; set; }
        public string ActorLastname { get; set; }
        public int ActorAge { get; set; }

    }
}
