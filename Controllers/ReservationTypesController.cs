using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using reservation.Data;
using reservation.Models;

namespace reservation.Controllers
{
    public class ReservationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservationType.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationType = await _context.ReservationType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationType == null)
            {
                return NotFound();
            }

            return View(reservationType);
        }

       
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,NumberOfPlaces")] ReservationType reservationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationType);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationType = await _context.ReservationType.FindAsync(id);
            if (reservationType == null)
            {
                return NotFound();
            }
            return View(reservationType);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,NumberOfPlaces")] ReservationType reservationType)
        {
            if (id != reservationType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationTypeExists(reservationType.Id))
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
            return View(reservationType);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationType = await _context.ReservationType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationType == null)
            {
                return NotFound();
            }

            return View(reservationType);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationType = await _context.ReservationType.FindAsync(id);
            _context.ReservationType.Remove(reservationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationTypeExists(int id)
        {
            return _context.ReservationType.Any(e => e.Id == id);
        }
    }
}
