using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiritofEastAustinDonationsAPI.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }
        public int CategoryId { get; set; }
        public string Remark { get; set; }


        public virtual Theme Theme { get; set; }
        public virtual Category Category { get; set; }
    }
}
