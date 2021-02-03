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
    public class HairDressingOptionsController : Controller
    {
        private readonly Hair_Dressing_Appointments_DBContext _context;

        public HairDressingOptionsController(Hair_Dressing_Appointments_DBContext context)
        {
            _context = context;
        }

        // GET: HairDressingOptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.HairDressingOption.ToListAsync());
        }

        // GET: HairDressingOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDressingOption = await _context.HairDressingOption
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairDressingOption == null)
            {
                return NotFound();
            }

            return View(hairDressingOption);
        }
        [Authorize]
        // GET: HairDressingOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HairDressingOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OptionName,Charge")] HairDressingOption hairDressingOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hairDressingOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hairDressingOption);
        }
        [Authorize]
        // GET: HairDressingOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDressingOption = await _context.HairDressingOption.FindAsync(id);
            if (hairDressingOption == null)
            {
                return NotFound();
            }
            return View(hairDressingOption);
        }

        // POST: HairDressingOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OptionName,Charge")] HairDressingOption hairDressingOption)
        {
            if (id != hairDressingOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairDressingOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairDressingOptionExists(hairDressingOption.Id))
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
            return View(hairDressingOption);
        }
        [Authorize]
        // GET: HairDressingOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDressingOption = await _context.HairDressingOption
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hairDressingOption == null)
            {
                return NotFound();
            }

            return View(hairDressingOption);
        }

        // POST: HairDressingOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hairDressingOption = await _context.HairDressingOption.FindAsync(id);
            _context.HairDressingOption.Remove(hairDressingOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairDressingOptionExists(int id)
        {
            return _context.HairDressingOption.Any(e => e.Id == id);
        }
    }
}
