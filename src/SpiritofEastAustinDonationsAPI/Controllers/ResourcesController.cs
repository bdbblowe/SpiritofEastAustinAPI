using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpiritofEastAustinDonationsAPI.Data;
using SpiritofEastAustinDonationsAPI.Models;

namespace SpiritofEastAustinDonationsAPI.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourcesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Resources
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resources.ToListAsync());
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources.SingleOrDefaultAsync(m => m.Id == id);
            if (resources == null)
            {
                return NotFound();
            }

            return View(resources);
        }

        // GET: Resources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ProjectCode,Resource,ThemeId")] Resources resources)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resources);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(resources);
        }

        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources.SingleOrDefaultAsync(m => m.Id == id);
            if (resources == null)
            {
                return NotFound();
            }
            return View(resources);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ProjectCode,Resource,ThemeId")] Resources resources)
        {
            if (id != resources.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resources);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourcesExists(resources.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(resources);
        }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources.SingleOrDefaultAsync(m => m.Id == id);
            if (resources == null)
            {
                return NotFound();
            }

            return View(resources);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resources = await _context.Resources.SingleOrDefaultAsync(m => m.Id == id);
            _context.Resources.Remove(resources);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ResourcesExists(int id)
        {
            return _context.Resources.Any(e => e.Id == id);
        }
    }
}
