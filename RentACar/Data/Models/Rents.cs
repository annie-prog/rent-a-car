using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Rents
    {
        public int Id { get; set; }
        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
