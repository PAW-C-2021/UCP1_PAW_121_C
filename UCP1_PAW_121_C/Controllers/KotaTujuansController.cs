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
    public class KotaTujuansController : Controller
    {
        private readonly SewaTravelContext _context;

        public KotaTujuansController(SewaTravelContext context)
        {
            _context = context;
        }

        // GET: KotaTujuans
        public async Task<IActionResult> Index()
        {
            return View(await _context.KotaTujuans.ToListAsync());
        }

        // GET: KotaTujuans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotaTujuan = await _context.KotaTujuans
                .FirstOrDefaultAsync(m => m.IdKotaTujuan == id);
            if (kotaTujuan == null)
            {
                return NotFound();
            }

            return View(kotaTujuan);
        }

        // GET: KotaTujuans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KotaTujuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKotaTujuan,KotaTujuan1,Biaya")] KotaTujuan kotaTujuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kotaTujuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kotaTujuan);
        }

        // GET: KotaTujuans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotaTujuan = await _context.KotaTujuans.FindAsync(id);
            if (kotaTujuan == null)
            {
                return NotFound();
            }
            return View(kotaTujuan);
        }

        // POST: KotaTujuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKotaTujuan,KotaTujuan1,Biaya")] KotaTujuan kotaTujuan)
        {
            if (id != kotaTujuan.IdKotaTujuan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kotaTujuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KotaTujuanExists(kotaTujuan.IdKotaTujuan))
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
            return View(kotaTujuan);
        }

        // GET: KotaTujuans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotaTujuan = await _context.KotaTujuans
                .FirstOrDefaultAsync(m => m.IdKotaTujuan == id);
            if (kotaTujuan == null)
            {
                return NotFound();
            }

            return View(kotaTujuan);
        }

        // POST: KotaTujuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kotaTujuan = await _context.KotaTujuans.FindAsync(id);
            _context.KotaTujuans.Remove(kotaTujuan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KotaTujuanExists(int id)
        {
            return _context.KotaTujuans.Any(e => e.IdKotaTujuan == id);
        }
    }
}
