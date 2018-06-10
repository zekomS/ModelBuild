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
    public class KindsController : Controller
    {
        private readonly PersoonKindContext _context;

        public KindsController(PersoonKindContext context)
        {
            _context = context;
        }

        // GET: Admin/Kinds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kinderen.ToListAsync());
        }

        // GET: Admin/Kinds/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kinderen
                .FirstOrDefaultAsync(m => m.id == id);
            if (kind == null)
            {
                return NotFound();
            }

            return View(kind);
        }

        // GET: Admin/Kinds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kinds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,Voornaam,leeftijd,id")] Kind kind)
        {
            if (ModelState.IsValid)
            {
                kind.id = Guid.NewGuid();
                _context.Add(kind);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kind);
        }

        // GET: Admin/Kinds/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kinderen.FindAsync(id);
            if (kind == null)
            {
                return NotFound();
            }
            return View(kind);
        }

        // POST: Admin/Kinds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Naam,Voornaam,leeftijd,id")] Kind kind)
        {
            if (id != kind.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kind);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindExists(kind.id))
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
            return View(kind);
        }

        // GET: Admin/Kinds/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kind = await _context.Kinderen
                .FirstOrDefaultAsync(m => m.id == id);
            if (kind == null)
            {
                return NotFound();
            }

            return View(kind);
        }

        // POST: Admin/Kinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var kind = await _context.Kinderen.FindAsync(id);
            _context.Kinderen.Remove(kind);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindExists(Guid id)
        {
            return _context.Kinderen.Any(e => e.id == id);
        }
    }
}
