using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Toki.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        [StringLength(25, MinimumLength = 1)]
        [Display(Name = "Name Of Rater")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string NameOfRater { get; set; }

        [Display(Name = "Rate Number")]
        [Required]
        public int RateNumber { get; set; }


        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Feedback")]
        [Required(AllowEmptyStrings = false)]
        public string Feedback { get; set; }

        public DateTime Time { get; set; }
    }
}
