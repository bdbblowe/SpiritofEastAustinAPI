using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SpiritofEastAustinDonationsAPI.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Common Name")]
        public int ResourcesId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Donation")]
        public decimal Amount { get; set; }

        //public virtual ApplicationUser User { get; set; }
        public virtual Resources Resources { get; set; }
    }
}
