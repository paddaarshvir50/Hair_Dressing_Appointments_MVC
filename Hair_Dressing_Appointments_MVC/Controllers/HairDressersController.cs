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
    public class HairDressersController : Controller
    {
        private readonly Hair_Dressing_Appointments_DBContext _context;

        public HairDressersController(Hair_Dressing_Appointments_DBContext context)
        {
            _context = context;
        }

        // GET: HairDressers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HairDresser.ToListAsync());
        }
        [Authorize]
        // GET: HairDressers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDresser = await _context.HairDresser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairDresser == null)
            {
                return NotFound();
            }

            return View(hairDresser);
        }
        [Authorize]
        // GET: HairDressers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HairDressers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsPermanent")] HairDresser hairDresser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hairDresser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hairDresser);
        }
        [Authorize]
        // GET: HairDressers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDresser = await _context.HairDresser.FindAsync(id);
            if (hairDresser == null)
            {
                return NotFound();
            }
            return View(hairDresser);
        }

        // POST: HairDressers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsPermanent")] HairDresser hairDresser)
        {
            if (id != hairDresser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairDresser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairDresserExists(hairDresser.Id))
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
            return View(hairDresser);
        }
        [Authorize]
        // GET: HairDressers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDresser = await _context.HairDresser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairDresser == null)
            {
                return NotFound();
            }

            return View(hairDresser);
        }

        // POST: HairDressers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hairDresser = await _context.HairDresser.FindAsync(id);
            _context.HairDresser.Remove(hairDresser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairDresserExists(int id)
        {
            return _context.HairDresser.Any(e => e.Id == id);
        }
    }
}
