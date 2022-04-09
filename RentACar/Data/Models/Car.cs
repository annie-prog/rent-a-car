using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Car
    {
        [Required]
        [Key]
        [Display(Name = "Car ID")]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        [Display(Name = "Seats")]
        public int CountPassengerSeats { get; set; }
        public string Description { get; set; }
        [Display(Name = "Daily price")]
        public decimal PriceForDay { get; set; }
    }
}
