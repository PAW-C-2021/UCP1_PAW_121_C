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
    public class SewaTravelsController : Controller
    {
        private readonly SewaTravelContext _context;

        public SewaTravelsController(SewaTravelContext context)
        {
            _context = context;
        }

        // GET: SewaTravels
        public async Task<IActionResult> Index()
        {
            var sewaTravelContext = _context.SewaTravels.Include(s => s.IdJadwalNavigation).Include(s => s.IdPelangganNavigation);
            return View(await sewaTravelContext.ToListAsync());
        }

        // GET: SewaTravels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaTravel = await _context.SewaTravels
                .Include(s => s.IdJadwalNavigation)
                .Include(s => s.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdSewaTravel == id);
            if (sewaTravel == null)
            {
                return NotFound();
            }

            return View(sewaTravel);
        }

        // GET: SewaTravels/Create
        public IActionResult Create()
        {
            ViewData["IdJadwal"] = new SelectList(_context.Jadwals, "IdJadwal", "IdJadwal");
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan");
            return View();
        }

        // POST: SewaTravels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSewaTravel,IdJadwal,IdPelanggan,Biaya,Kuota,TotalBayar")] SewaTravel sewaTravel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sewaTravel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJadwal"] = new SelectList(_context.Jadwals, "IdJadwal", "IdJadwal", sewaTravel.IdJadwal);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan", sewaTravel.IdPelanggan);
            return View(sewaTravel);
        }

        // GET: SewaTravels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaTravel = await _context.SewaTravels.FindAsync(id);
            if (sewaTravel == null)
            {
                return NotFound();
            }
            ViewData["IdJadwal"] = new SelectList(_context.Jadwals, "IdJadwal", "IdJadwal", sewaTravel.IdJadwal);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan", sewaTravel.IdPelanggan);
            return View(sewaTravel);
        }

        // POST: SewaTravels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSewaTravel,IdJadwal,IdPelanggan,Biaya,Kuota,TotalBayar")] SewaTravel sewaTravel)
        {
            if (id != sewaTravel.IdSewaTravel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sewaTravel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SewaTravelExists(sewaTravel.IdSewaTravel))
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
            ViewData["IdJadwal"] = new SelectList(_context.Jadwals, "IdJadwal", "IdJadwal", sewaTravel.IdJadwal);
            ViewData["IdPelanggan"] = new SelectList(_context.Pelanggans, "IdPelanggan", "IdPelanggan", sewaTravel.IdPelanggan);
            return View(sewaTravel);
        }

        // GET: SewaTravels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaTravel = await _context.SewaTravels
                .Include(s => s.IdJadwalNavigation)
                .Include(s => s.IdPelangganNavigation)
                .FirstOrDefaultAsync(m => m.IdSewaTravel == id);
            if (sewaTravel == null)
            {
                return NotFound();
            }

            return View(sewaTravel);
        }

        // POST: SewaTravels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sewaTravel = await _context.SewaTravels.FindAsync(id);
            _context.SewaTravels.Remove(sewaTravel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SewaTravelExists(int id)
        {
            return _context.SewaTravels.Any(e => e.IdSewaTravel == id);
        }
    }
}
