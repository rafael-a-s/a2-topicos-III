using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;

namespace PjA2Tp3.Controllers
{
    public class EnderecoEmpresasController : Controller
    {
        private readonly TpContext _context;
        private readonly ISessao _sessao;

        public EnderecoEmpresasController(TpContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        // GET: EnderecoEmpresas
        public async Task<IActionResult> Index()
        {
            var tpContext = _context.EnderecoEmpresas.Include(e => e.Empresa);
            return View(await tpContext.ToListAsync());
        }

        // GET: EnderecoEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EnderecoEmpresas == null)
            {
                return NotFound();
            }

            var enderecoEmpresa = await _context.EnderecoEmpresas
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoEmpresa == null)
            {
                return NotFound();
            }

            return View(enderecoEmpresa);
        }

        // GET: EnderecoEmpresas/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj");
            return View();
        }

        // POST: EnderecoEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Bairro,Logradouro,TipoLogradouro,Cidade,Estado,EmpresaId")] EnderecoEmpresa enderecoEmpresa)
        {
                var aux = _sessao.BuscarSessao("empLogado");
                Empresa emp = _context.Empresas.FirstOrDefault(e => e.Id == aux.Id);
                enderecoEmpresa.Empresa = emp;
                enderecoEmpresa.EmpresaId = aux.Id;

                _context.Add(enderecoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Empresas", emp);
        }

        // GET: EnderecoEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EnderecoEmpresas == null)
            {
                return NotFound();
            }

            var enderecoEmpresa = await _context.EnderecoEmpresas.FindAsync(id);
            if (enderecoEmpresa == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj", enderecoEmpresa.EmpresaId);
            return View(enderecoEmpresa);
        }

        // POST: EnderecoEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Bairro,Logradouro,TipoLogradouro,Cidade,Estado,EmpresaId")] EnderecoEmpresa enderecoEmpresa)
        {
            if (id != enderecoEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoEmpresaExists(enderecoEmpresa.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Cnpj", enderecoEmpresa.EmpresaId);
            return View(enderecoEmpresa);
        }

        // GET: EnderecoEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EnderecoEmpresas == null)
            {
                return NotFound();
            }

            var enderecoEmpresa = await _context.EnderecoEmpresas
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoEmpresa == null)
            {
                return NotFound();
            }

            return View(enderecoEmpresa);
        }

        // POST: EnderecoEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EnderecoEmpresas == null)
            {
                return Problem("Entity set 'TpContext.EnderecoEmpresas'  is null.");
            }
            var enderecoEmpresa = await _context.EnderecoEmpresas.FindAsync(id);
            if (enderecoEmpresa != null)
            {
                _context.EnderecoEmpresas.Remove(enderecoEmpresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoEmpresaExists(int id)
        {
          return _context.EnderecoEmpresas.Any(e => e.Id == id);
        }
    }
}
