using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSCB766_RentACar.Models
{
    public class Rent
    {
        [Key]
        [Display(Name = "Rent ID")]
        public int RentID { get; set; }
        [Display(Name = "Vehicle ID")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Display(Name = "Rent Date")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        [Display(Name = "Current Price Per Day")]
        public float Cost { get; set; }

    }
}
