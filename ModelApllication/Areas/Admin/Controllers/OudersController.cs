using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelApllication.Data;
using ModelApllication.Entities;

namespace ModelApllication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OudersController : Controller
    {
        private readonly PersoonKindContext _context;

        public OudersController(PersoonKindContext context)
        {
            _context = context;
        }

        // GET: Admin/Ouders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ouders.ToListAsync());
        }

        // GET: Admin/Ouders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ouder = await _context.Ouders
                .FirstOrDefaultAsync(m => m.id == id);
            if (ouder == null)
            {
                return NotFound();
            }

            return View(ouder);
        }

        // GET: Admin/Ouders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ouders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,Voornaam,leeftijd,id")] Ouder ouder)
        {
            if (ModelState.IsValid)
            {
                ouder.id = Guid.NewGuid();
                _context.Add(ouder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ouder);
        }

        // GET: Admin/Ouders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ouder = await _context.Ouders.FindAsync(id);
            if (ouder == null)
            {
                return NotFound();
            }
            return View(ouder);
        }

        // POST: Admin/Ouders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Naam,Voornaam,leeftijd,id")] Ouder ouder)
        {
            if (id != ouder.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ouder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OuderExists(ouder.id))
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
            return View(ouder);
        }

        // GET: Admin/Ouders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ouder = await _context.Ouders
                .FirstOrDefaultAsync(m => m.id == id);
            if (ouder == null)
            {
                return NotFound();
            }

            return View(ouder);
        }

        // POST: Admin/Ouders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ouder = await _context.Ouders.FindAsync(id);
            _context.Ouders.Remove(ouder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OuderExists(Guid id)
        {
            return _context.Ouders.Any(e => e.id == id);
        }
    }
}
