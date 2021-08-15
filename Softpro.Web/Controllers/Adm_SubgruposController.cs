using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Softpro.Common.Entities;
using Softpro.Web.Data;

namespace Softpro.Web.Controllers
{
    public class Adm_SubgruposController : Controller
    {
        private readonly DataContext _context;

        public Adm_SubgruposController(DataContext context)
        {
            _context = context;
        }

        // GET: Adm_Subgrupos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adm_Subgrupos.ToListAsync());
        }

        // GET: Adm_Subgrupos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adm_Subgrupos = await _context.Adm_Subgrupos
                .FirstOrDefaultAsync(m => m.SubgrupoID == id);
            if (adm_Subgrupos == null)
            {
                return NotFound();
            }

            return View(adm_Subgrupos);
        }

        // GET: Adm_Subgrupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adm_Subgrupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubgrupoID,Subgrupo")] Adm_Subgrupos adm_Subgrupos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adm_Subgrupos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adm_Subgrupos);
        }

        // GET: Adm_Subgrupos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adm_Subgrupos = await _context.Adm_Subgrupos.FindAsync(id);
            if (adm_Subgrupos == null)
            {
                return NotFound();
            }
            return View(adm_Subgrupos);
        }

        // POST: Adm_Subgrupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SubgrupoID,Subgrupo")] Adm_Subgrupos adm_Subgrupos)
        {
            if (id != adm_Subgrupos.SubgrupoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adm_Subgrupos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Adm_SubgruposExists(adm_Subgrupos.SubgrupoID))
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
            return View(adm_Subgrupos);
        }

        // GET: Adm_Subgrupos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adm_Subgrupos = await _context.Adm_Subgrupos
                .FirstOrDefaultAsync(m => m.SubgrupoID == id);
            if (adm_Subgrupos == null)
            {
                return NotFound();
            }

            return View(adm_Subgrupos);
        }

        // POST: Adm_Subgrupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var adm_Subgrupos = await _context.Adm_Subgrupos.FindAsync(id);
            _context.Adm_Subgrupos.Remove(adm_Subgrupos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Adm_SubgruposExists(string id)
        {
            return _context.Adm_Subgrupos.Any(e => e.SubgrupoID == id);
        }
    }
}
