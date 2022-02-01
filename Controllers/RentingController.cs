using CSCB766_RentACar.Data;
using CSCB766_RentACar.Lib;
using CSCB766_RentACar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSCB766_RentACar.Controllers
{
    
    public class RentingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public RentingController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;

        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //var userId = _userService.GetUserId();
            return View(await _context.RentedVehicles.ToListAsync());
        }

        public async Task<IActionResult> Display()
        {
            return View(await _context.Vehicles.ToListAsync());
        }
        [Authorize]
        public  async Task<IActionResult> RentCar(int? id)
        {
            var userId = _userService.GetUserId();
            var vehicleId = await _context.Vehicles.FindAsync(id);

            if (vehicleId == null)
            {
                return NotFound();
            }
            Rent rent = new Rent()
            {
                UserId = userId,
                VehicleId = vehicleId.VehicleID,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Today.AddDays(1),
                Cost = vehicleId.RentalPricePerDay
            };
            return View(rent);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RentCar(Rent rent)
        {
            if (ModelState.IsValid)
            {
                int vid = rent.VehicleId;
                int from = rent.DateFrom.Day;
                int to = rent.DateTo.Day;
                int totalDays = to - from;
                float price = rent.Cost;
                price *= totalDays;
                rent.Cost = price;
                _context.Add(rent);
                await _context.SaveChangesAsync();

                var vehicle = await _context.Vehicles.FindAsync(vid);
                vehicle.Status = "Unavailable";
                _context.Update(vehicle);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(rent);
           
        }

    }
}
