using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_121_C.Models;

namespace UCP1_PAW_121_C.Controllers
{
    public class MobilsController : Controller
    {
        private readonly SewaTravelContext _context;

        public MobilsController(SewaTravelContext context)
        {
            _context = context;
        }

        // GET: Mobils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mobils.ToListAsync());
        }

        // GET: Mobils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobil = await _context.Mobils
                .FirstOrDefaultAsync(m => m.IdMobil == id);
            if (mobil == null)
            {
                return NotFound();
            }

            return View(mobil);
        }

        // GET: Mobils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mobils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMobil,JenisMobil,NamaMobil,SewaMobil,Status")] Mobil mobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobil);
        }

        // GET: Mobils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobil = await _context.Mobils.FindAsync(id);
            if (mobil == null)
            {
                return NotFound();
            }
            return View(mobil);
        }

        // POST: Mobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMobil,JenisMobil,NamaMobil,SewaMobil,Status")] Mobil mobil)
        {
            if (id != mobil.IdMobil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilExists(mobil.IdMobil))
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
            return View(mobil);
        }

        // GET: Mobils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobil = await _context.Mobils
                .FirstOrDefaultAsync(m => m.IdMobil == id);
            if (mobil == null)
            {
                return NotFound();
            }

            return View(mobil);
        }

        // POST: Mobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobil = await _context.Mobils.FindAsync(id);
            _context.Mobils.Remove(mobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilExists(int id)
        {
            return _context.Mobils.Any(e => e.IdMobil == id);
        }
    }
}
