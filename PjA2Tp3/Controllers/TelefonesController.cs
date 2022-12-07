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
    public class TelefonesController : Controller
    {
        private readonly TpContext _context;
        private readonly ISessao _sessao;

        public TelefonesController(TpContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var tpContext = _context.Telefones.Include(t => t.Usuario);
            return View(await tpContext.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Telefones == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefones
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // GET: Telefones/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf");
            return View();
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ddd,Numero,UsuarioId")] Telefone telefone)
        {
            var aux = _sessao.BuscarSessao("usuLogado");
            Usuario usu = _context.Usuarios.FirstOrDefault(e => e.Id == aux.Id);
            telefone.Usuario = usu;
            telefone.UsuarioId = aux.Id;    

            _context.Add(telefone);
            await _context.SaveChangesAsync();
            return RedirectToAction("Profile", "Usuarios", usu);

        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Telefones == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", telefone.UsuarioId);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ddd,Numero,UsuarioId")] Telefone telefone)
        {
            if (id != telefone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefoneExists(telefone.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", telefone.UsuarioId);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Telefones == null)
            {
                return NotFound();
            }

            var telefone = await _context.Telefones
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefone == null)
            {
                return NotFound();
            }

            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Telefones == null)
            {
                return Problem("Entity set 'TpContext.Telefones'  is null.");
            }
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone != null)
            {
                _context.Telefones.Remove(telefone);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefoneExists(int id)
        {
          return _context.Telefones.Any(e => e.Id == id);
        }
    }
}
