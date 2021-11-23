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
    public class PelanggansController : Controller
    {
        private readonly SewaTravelContext _context;

        public PelanggansController(SewaTravelContext context)
        {
            _context = context;
        }

        // GET: Pelanggans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pelanggans.ToListAsync());
        }

        // GET: Pelanggans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggan = await _context.Pelanggans
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (pelanggan == null)
            {
                return NotFound();
            }

            return View(pelanggan);
        }

        // GET: Pelanggans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pelanggans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelanggan,NamaPelanggan,NoHpPelanggan,Alamat")] Pelanggan pelanggan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelanggan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelanggan);
        }

        // GET: Pelanggans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggan = await _context.Pelanggans.FindAsync(id);
            if (pelanggan == null)
            {
                return NotFound();
            }
            return View(pelanggan);
        }

        // POST: Pelanggans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelanggan,NamaPelanggan,NoHpPelanggan,Alamat")] Pelanggan pelanggan)
        {
            if (id != pelanggan.IdPelanggan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelanggan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelangganExists(pelanggan.IdPelanggan))
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
            return View(pelanggan);
        }

        // GET: Pelanggans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pelanggan = await _context.Pelanggans
                .FirstOrDefaultAsync(m => m.IdPelanggan == id);
            if (pelanggan == null)
            {
                return NotFound();
            }

            return View(pelanggan);
        }

        // POST: Pelanggans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pelanggan = await _context.Pelanggans.FindAsync(id);
            _context.Pelanggans.Remove(pelanggan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelangganExists(int id)
        {
            return _context.Pelanggans.Any(e => e.IdPelanggan == id);
        }
    }
}
