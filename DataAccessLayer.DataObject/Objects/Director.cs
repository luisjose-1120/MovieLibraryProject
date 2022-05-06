using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Director
    {
        public Director()
        {
            Movie = new HashSet<Movie>();
        }

        public long IdDirector { get; set; }
        public string DirectorName { get; set; }
        public string DirectorLastname { get; set; }
        public int DirectorAge { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
