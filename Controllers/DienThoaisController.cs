using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHOPDienThoai.Data;
using SHOPDienThoai.Models;

namespace SHOPDienThoai.Controllers
{
    public class DienThoaisController : Controller
    {
        private readonly SHOPDienThoaiContext _context;

        public DienThoaisController(SHOPDienThoaiContext context)
        {
            _context = context;
        }

        // GET: DienThoais
        public async Task<IActionResult> Index()
        {
            return View(await _context.DienThoai.ToListAsync());
        }

        // GET: DienThoais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dienThoai = await _context.DienThoai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dienThoai == null)
            {
                return NotFound();
            }

            return View(dienThoai);
        }

        // GET: DienThoais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DienThoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Color,Price")] DienThoai dienThoai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dienThoai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dienThoai);
        }

        // GET: DienThoais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dienThoai = await _context.DienThoai.FindAsync(id);
            if (dienThoai == null)
            {
                return NotFound();
            }
            return View(dienThoai);
        }

        // POST: DienThoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Color,Price")] DienThoai dienThoai)
        {
            if (id != dienThoai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dienThoai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DienThoaiExists(dienThoai.Id))
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
            return View(dienThoai);
        }

        // GET: DienThoais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dienThoai = await _context.DienThoai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dienThoai == null)
            {
                return NotFound();
            }

            return View(dienThoai);
        }

        // POST: DienThoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dienThoai = await _context.DienThoai.FindAsync(id);
            _context.DienThoai.Remove(dienThoai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DienThoaiExists(int id)
        {
            return _context.DienThoai.Any(e => e.Id == id);
        }
    }
}
