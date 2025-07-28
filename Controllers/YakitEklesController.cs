using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArabaSatis.Data;
using ArabaSatis.Models;

namespace ArabaSatis.Controllers
{
    public class YakitEklesController : Controller
    {
        private readonly ArabamDbContext _context;

        public YakitEklesController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: YakitEkles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yakits.ToListAsync());
        }

        // GET: YakitEkles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yakitEkle = await _context.Yakits
                .FirstOrDefaultAsync(m => m.YakitId == id);
            if (yakitEkle == null)
            {
                return NotFound();
            }

            return View(yakitEkle);
        }

        // GET: YakitEkles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YakitEkles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YakitId,YakitAdi,YakitTuru")] YakitEkle yakitEkle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yakitEkle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yakitEkle);
        }

        // GET: YakitEkles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yakitEkle = await _context.Yakits.FindAsync(id);
            if (yakitEkle == null)
            {
                return NotFound();
            }
            return View(yakitEkle);
        }

        // POST: YakitEkles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YakitId,YakitAdi,YakitTuru")] YakitEkle yakitEkle)
        {
            if (id != yakitEkle.YakitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yakitEkle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YakitEkleExists(yakitEkle.YakitId))
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
            return View(yakitEkle);
        }

        // GET: YakitEkles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yakitEkle = await _context.Yakits
                .FirstOrDefaultAsync(m => m.YakitId == id);
            if (yakitEkle == null)
            {
                return NotFound();
            }

            return View(yakitEkle);
        }

        // POST: YakitEkles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yakitEkle = await _context.Yakits.FindAsync(id);
            if (yakitEkle != null)
            {
                _context.Yakits.Remove(yakitEkle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YakitEkleExists(int id)
        {
            return _context.Yakits.Any(e => e.YakitId == id);
        }
    }
}
