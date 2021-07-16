using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reservation.Data;
using reservation.Models;

namespace reservation.Controllers
{
    
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;


        public ReservationsController(ApplicationDbContext context  , UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index(DateTime date , string type )
        {
            

            return View(await _context.Reservations.Include(r => r.ReservationType).Include(r => r.User).Where(r => r.Date == date && r.ReservationType.Type == type).OrderBy(r=> r.User.ReservationCount).ToListAsync());
        }

        public async Task<JsonResult> res()
        {

           
            
            string id = _userManager.GetUserId(User); 
            
            var reservations = await _context.Reservations.Include(r => r.ReservationType).Include(r => r.User).Where(r => r.User.Id == id).ToListAsync();

            return Json(reservations);
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

     
        
        [HttpPost]
        
        public async Task<JsonResult> Create( DateTime date , string type ) {

             string id = _userManager.GetUserId(User); 
            
            var resType = await _context.ReservationType.ToListAsync();
            var user = await _userManager.GetUserAsync(User);

            var reservation = new Reservation
            {
                Date = date,
                ReservationType = resType.Where(r => r.Type == type).FirstOrDefault(),
                User = user
                
            };

            int count ;

            if(type == "evening")
            {
                count = 20;
            }else if(type == "day")
            {
                count = 40;
            }
            else
            {
                count = 30;
            }

            user.ReservationCount += count ;

          await  _userManager.UpdateAsync(user);


                _context.Add(reservation);
                
                await _context.SaveChangesAsync();


            var reservations = await _context.Reservations.Include(r => r.ReservationType).Where(r => r.User.Id == id).ToListAsync();

            return Json(reservations);
        }


        [HttpPost]

        public async Task<IActionResult> Validate(DateTime date, string type)
        {

            var reservations = await _context.Reservations.Include(r => r.ReservationType).Include(r => r.User).Where(r => r.Date == date && r.ReservationType.Type == type).ToListAsync();

            reservations.ForEach(r => {
                r.IsValid = true;
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { date = date, type = type });

        }

            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,IsValid")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

       
        [HttpPost, ActionName("Delete")]
        
        public async Task<JsonResult> DeleteConfirmed(int id)
        {
            string Id = _userManager.GetUserId(User);
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            var reservations = await _context.Reservations.Include(r => r.ReservationType).Where(r => r.User.Id == Id).ToListAsync();

            return Json(reservations);

        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
