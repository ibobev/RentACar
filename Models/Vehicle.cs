using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSCB766_RentACar.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        [Required(ErrorMessage = "Manufacturer is required!")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Model is required!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Plate Number is required!")]
        [DisplayName("Plate Number")]
        public string PlateNumber { get; set; }
        [Required(ErrorMessage = "Rental price per day is required!")]
        [DisplayName("Rental Price Per Day")]
        [Range(1, float.MaxValue)]
        public float RentalPricePerDay { get; set; }

        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload Image")]
        public IFormFile ImageFile { get; set; }
        public string Status { get; set; }
        public List<Rent> RentVehicles { get; set; }

    }
}
