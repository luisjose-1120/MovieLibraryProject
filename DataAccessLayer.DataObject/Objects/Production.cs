using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Production
    {
        public Production()
        {
            Movie = new HashSet<Movie>();
        }

        public long IdProduction { get; set; }
        public string ProductionName { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
