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
    public class SewaMobilsController : Controller
    {
        private readonly SewaTravelContext _context;

        public SewaMobilsController(SewaTravelContext context)
        {
            _context = context;
        }

        // GET: SewaMobils
        public async Task<IActionResult> Index()
        {
            var sewaTravelContext = _context.SewaMobils.Include(s => s.IdDriverNavigation).Include(s => s.IdMobilNavigation).Include(s => s.IdPelangganNavigation);
            return View(await sewaTravelContext.ToListAsync());
        }

        // GET: SewaMobils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaMobil = await _context.SewaMobils
                .Include(s => s.IdDriverNavigation)
                .Include(s => s.IdMobilNavigation)
                .Include(s => s.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdSewaMobil == id);
            if (sewaMobil == null)
            {
                return NotFound();
            }

            return View(sewaMobil);
        }

        // GET: SewaMobils/Create
        public IActionResult Create()
        {
            ViewData["IdDriver"] = new SelectList(_context.Drivers, "IdDriver", "IdDriver");
            ViewData["IdMobil"] = new SelectList(_context.Mobils, "IdMobil", "IdMobil");
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan");
            return View();
        }

        // POST: SewaMobils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSewaMobil,IdDriver,IdMobil,IdPelanggan,JumlahHari,Total")] SewaMobil sewaMobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sewaMobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDriver"] = new SelectList(_context.Drivers, "IdDriver", "IdDriver", sewaMobil.IdDriver);
            ViewData["IdMobil"] = new SelectList(_context.Mobils, "IdMobil", "IdMobil", sewaMobil.IdMobil);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan", sewaMobil.IdPelanggan);
            return View(sewaMobil);
        }

        // GET: SewaMobils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaMobil = await _context.SewaMobils.FindAsync(id);
            if (sewaMobil == null)
            {
                return NotFound();
            }
            ViewData["IdDriver"] = new SelectList(_context.Drivers, "IdDriver", "IdDriver", sewaMobil.IdDriver);
            ViewData["IdMobil"] = new SelectList(_context.Mobils, "IdMobil", "IdMobil", sewaMobil.IdMobil);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan", sewaMobil.IdPelanggan);
            return View(sewaMobil);
        }

        // POST: SewaMobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSewaMobil,IdDriver,IdMobil,IdPelanggan,JumlahHari,Total")] SewaMobil sewaMobil)
        {
            if (id != sewaMobil.IdSewaMobil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sewaMobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SewaMobilExists(sewaMobil.IdSewaMobil))
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
            ViewData["IdDriver"] = new SelectList(_context.Drivers, "IdDriver", "IdDriver", sewaMobil.IdDriver);
            ViewData["IdMobil"] = new SelectList(_context.Mobils, "IdMobil", "IdMobil", sewaMobil.IdMobil);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan", sewaMobil.IdPelanggan);
            return View(sewaMobil);
        }

        // GET: SewaMobils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaMobil = await _context.SewaMobils
                .Include(s => s.IdDriverNavigation)
                .Include(s => s.IdMobilNavigation)
                .Include(s => s.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdSewaMobil == id);
            if (sewaMobil == null)
            {
                return NotFound();
            }

            return View(sewaMobil);
        }

        // POST: SewaMobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sewaMobil = await _context.SewaMobils.FindAsync(id);
            _context.SewaMobils.Remove(sewaMobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SewaMobilExists(int id)
        {
            return _context.SewaMobils.Any(e => e.IdSewaMobil == id);
        }
    }
}
