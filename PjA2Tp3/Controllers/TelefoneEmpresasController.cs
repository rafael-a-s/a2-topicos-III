using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;

namespace PjA2Tp3.Controllers
{
    public class TelefoneEmpresasController : Controller
    {
        private readonly TpContext _context;
        private readonly ISessao _sessao;
        public TelefoneEmpresasController(TpContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        // GET: TelefoneEmpresas
        public async Task<IActionResult> Index()
        {
            var tpContext = _context.TelefoneEmpresas.Include(t => t.Empresa);
            return View(await tpContext.ToListAsync());
        }

        // GET: TelefoneEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TelefoneEmpresas == null)
            {
                return NotFound();
            }

            var telefoneEmpresa = await _context.TelefoneEmpresas
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefoneEmpresa == null)
            {
                return NotFound();
            }

            return View(telefoneEmpresa);
        }

        // GET: TelefoneEmpresas/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia");
            return View();
        }

        // POST: TelefoneEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ddd,Numero,EmpresaId")] TelefoneEmpresa telefoneEmpresa)
        {
            var aux = _sessao.BuscarSessao("empLogado");
            Empresa emp = _context.Empresas.FirstOrDefault(e => e.Id == aux.Id);
            telefoneEmpresa.Empresa = emp;
            telefoneEmpresa.EmpresaId = aux.Id;
            
           
                _context.Add(telefoneEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Empresas", emp);
           
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia", telefoneEmpresa.EmpresaId);
            
        }

        // GET: TelefoneEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TelefoneEmpresas == null)
            {
                return NotFound();
            }

            var telefoneEmpresa = await _context.TelefoneEmpresas.FindAsync(id);
            if (telefoneEmpresa == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia", telefoneEmpresa.EmpresaId);
            return View(telefoneEmpresa);
        }

        // POST: TelefoneEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ddd,Numero,EmpresaId")] TelefoneEmpresa telefoneEmpresa)
        {
            if (id != telefoneEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefoneEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneEmpresaExists(telefoneEmpresa.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia", telefoneEmpresa.EmpresaId);
            return View(telefoneEmpresa);
        }

        // GET: TelefoneEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TelefoneEmpresas == null)
            {
                return NotFound();
            }

            var telefoneEmpresa = await _context.TelefoneEmpresas
                .Include(t => t.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefoneEmpresa == null)
            {
                return NotFound();
            }

            return View(telefoneEmpresa);
        }

        // POST: TelefoneEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TelefoneEmpresas == null)
            {
                return Problem("Entity set 'TpContext.TelefoneEmpresas'  is null.");
            }
            var telefoneEmpresa = await _context.TelefoneEmpresas.FindAsync(id);
            if (telefoneEmpresa != null)
            {
                _context.TelefoneEmpresas.Remove(telefoneEmpresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneEmpresaExists(int id)
        {
          return _context.TelefoneEmpresas.Any(e => e.Id == id);
        }
    }
}
