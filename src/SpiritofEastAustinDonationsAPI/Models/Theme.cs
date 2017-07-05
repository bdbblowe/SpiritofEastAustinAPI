using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiritofEastAustinDonationsAPI.Models
{
    public class Theme
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Resources> Resources { get; set; }


    }
}
