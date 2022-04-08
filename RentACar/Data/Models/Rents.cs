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

        [Required]
        [ForeignKey("CarId")]
        public Car Car { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
 
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
