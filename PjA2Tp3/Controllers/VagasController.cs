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
    public class VagasController : Controller
    {
        private readonly TpContext _context;
        private readonly ISessao _sessao;

        public VagasController(TpContext context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            var tpContext = _context.Vagas.Include(v => v.Empresas);
            return View(await tpContext.ToListAsync());
        }

        // GET: Vagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .Include(v => v.Empresas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // GET: Vagas/Create
        public IActionResult Create()
        {
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "Cnpj");
            ViewData["Tag"] = new SelectList(_context.Tags, "Id", "Label");
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Remuneracao,Curtidas,Turno,Modalidade,EmpresasId")] Vaga vaga)
        {
            StringValues TagId = Request.Form["Tags"];

            var empresa = _sessao.BuscarSessao("empLogado");
            vaga.EmpresasId = empresa.Id;
            vaga.Empresas = _context.Empresas.FirstOrDefault(e => e.Id == empresa.Id);

            foreach (var item in TagId)
            {
                int id = int.Parse(item);
                Tag t = new Tag();
                t = _context.Tags.FirstOrDefault(t => t.Id == id);
                VagaTag vt = new VagaTag();
                vt.TagId = t.Id;
                vt.Tag = t;
                vt.Vaga = vaga;
                vaga.Tags = new List<VagaTag>();
                vaga.Tags.Add(vt);  
            }

            _context.Add(vaga);
            await _context.SaveChangesAsync();
          
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "Cnpj", vaga.EmpresasId);
            ViewData["Tag"] = new SelectList(_context.Tags, "Id", "Label");
            return RedirectToAction("Index", "Home");
        }

        // GET: Vagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null)
            {
                return NotFound();
            }
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "Cnpj", vaga.EmpresasId);
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Remuneracao,Curtidas,Turno,Modalidade,EmpresasId")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaExists(vaga.Id))
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
            ViewData["EmpresasId"] = new SelectList(_context.Empresas, "Id", "Cnpj", vaga.EmpresasId);
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vagas == null)
            {
                return NotFound();
            }

            var vaga = await _context.Vagas
                .Include(v => v.Empresas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vagas == null)
            {
                return Problem("Entity set 'TpContext.Vagas'  is null.");
            }
            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga != null)
            {
                _context.Vagas.Remove(vaga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaExists(int id)
        {
          return _context.Vagas.Any(e => e.Id == id);
        }
    }
}
