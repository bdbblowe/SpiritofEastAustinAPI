using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiritofEastAustinDonationsAPI.Models
{
    public class Resources
    {
        public int Id { get; set; }
        public string Resource { get; set; }
        public int ThemeId { get; set; }
        public string Description { get; set; }
        public string ProjectCode { get; set; }


        public virtual Theme Theme { get; set; }
    }
}
