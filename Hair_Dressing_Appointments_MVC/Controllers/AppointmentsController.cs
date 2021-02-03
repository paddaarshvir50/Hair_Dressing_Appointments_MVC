using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hair_Dressing_Appointments_MVC.Data;
using Hair_Dressing_Appointments_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hair_Dressing_Appointments_MVC.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly Hair_Dressing_Appointments_DBContext _context;

        public AppointmentsController(Hair_Dressing_Appointments_DBContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var hair_Dressing_Appointments_DBContext = _context.Appointment.Include(a => a.Client).Include(a => a.HairDresser).Include(a => a.HairDressingOption);
            return View(await hair_Dressing_Appointments_DBContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Client)
                .Include(a => a.HairDresser)
                .Include(a => a.HairDressingOption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        [Authorize]
        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id");
            ViewData["HairDresserId"] = new SelectList(_context.HairDresser, "Id", "Id");
            ViewData["HairDressingOptionId"] = new SelectList(_context.HairDressingOption, "Id", "Id");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,HairDresserId,HairDressingOptionId")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", appointment.ClientId);
            ViewData["HairDresserId"] = new SelectList(_context.HairDresser, "Id", "Id", appointment.HairDresserId);
            ViewData["HairDressingOptionId"] = new SelectList(_context.HairDressingOption, "Id", "Id", appointment.HairDressingOptionId);
            return View(appointment);
        }
        [Authorize]
        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", appointment.ClientId);
            ViewData["HairDresserId"] = new SelectList(_context.HairDresser, "Id", "Id", appointment.HairDresserId);
            ViewData["HairDressingOptionId"] = new SelectList(_context.HairDressingOption, "Id", "Id", appointment.HairDressingOptionId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,HairDresserId,HairDressingOptionId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", appointment.ClientId);
            ViewData["HairDresserId"] = new SelectList(_context.HairDresser, "Id", "Id", appointment.HairDresserId);
            ViewData["HairDressingOptionId"] = new SelectList(_context.HairDressingOption, "Id", "Id", appointment.HairDressingOptionId);
            return View(appointment);
        }
        [Authorize]
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Client)
                .Include(a => a.HairDresser)
                .Include(a => a.HairDressingOption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
