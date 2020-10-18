using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainelCovid19.Data;
using PainelCovid19.Models;

namespace PainelCovid19.Controllers
{
    public class DadosCovidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadosCovidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadosCovids
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DadosCovid.Include(d => d.Pais);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DadosCovids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosCovid = await _context.DadosCovid
                .Include(d => d.Pais)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (dadosCovid == null)
            {
                return NotFound();
            }

            return View(dadosCovid);
        }

        // GET: DadosCovids/Create
        public IActionResult Create()
        {
            ViewData["PaisId"] = new SelectList(_context.Pais, "Codigo", "Nome");
            return View();
        }

        // POST: DadosCovids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,CasosConfirmados,Mortes,Recuperados,PaisId")] DadosCovid dadosCovid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosCovid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisId"] = new SelectList(_context.Pais, "Codigo", "Codigo", dadosCovid.PaisId);
            return View(dadosCovid);
        }

        // GET: DadosCovids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosCovid = await _context.DadosCovid.FindAsync(id);
            if (dadosCovid == null)
            {
                return NotFound();
            }
            ViewData["PaisId"] = new SelectList(_context.Pais, "Nome", "Nome", dadosCovid.PaisId);
            return View(dadosCovid);
        }

        // POST: DadosCovids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,CasosConfirmados,Mortes,Recuperados,PaisId")] DadosCovid dadosCovid)
        {
            if (id != dadosCovid.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosCovid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosCovidExists(dadosCovid.Codigo))
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
            ViewData["PaisId"] = new SelectList(_context.Pais, "Codigo", "Codigo", dadosCovid.PaisId);
            return View(dadosCovid);
        }

        // GET: DadosCovids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosCovid = await _context.DadosCovid
                .Include(d => d.Pais)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (dadosCovid == null)
            {
                return NotFound();
            }

            return View(dadosCovid);
        }

        // POST: DadosCovids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosCovid = await _context.DadosCovid.FindAsync(id);
            _context.DadosCovid.Remove(dadosCovid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosCovidExists(int id)
        {
            return _context.DadosCovid.Any(e => e.Codigo == id);
        }
    }
}
