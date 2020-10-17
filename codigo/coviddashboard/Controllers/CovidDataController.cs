using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using coviddashboard.Data;
using coviddashboard.Models;
using Microsoft.AspNetCore.Authorization;
using app_aspnet_core.Models;

namespace coviddashboard.Controllers
{
    [Authorize]
    public class CovidDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CovidDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CovidData
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CovidData.Include(d => d.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CovidData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidData = await _context.CovidData
                .Include(d => d.Country)
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (covidData == null)
            {
                return NotFound();
            }

            return View(covidData);
        }

        // GET: CovidData/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name");
            return View();
        }

        // POST: CovidData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CountryId,ConfirmedCases,Deaths,Recovered")] CovidData covidData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covidData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", covidData.CountryId);
            return View(covidData);
        }

        // GET: CovidData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidData = await _context.CovidData.FindAsync(id);
            if (covidData == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", covidData.CountryId);
            return View(covidData);
        }

        // POST: CovidData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CountryId,ConfirmedCases,Deaths,Recovered")] CovidData covidData)
        {
            if (id != covidData.CountryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covidData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidDataExists(covidData.CountryId))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "Name", covidData.CountryId);
            return View(covidData);
        }

        // GET: CovidData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidData = await _context.CovidData
                .Include(d => d.Country)
                .FirstOrDefaultAsync(m => m.CountryId == id);
            if (covidData == null)
            {
                return NotFound();
            }

            return View(covidData);
        }

        // POST: CovidData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covidData = await _context.CovidData.FindAsync(id);
            _context.CovidData.Remove(covidData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidDataExists(int id)
        {
            return _context.CovidData.Any(e => e.CountryId == id);
        }
    }
}