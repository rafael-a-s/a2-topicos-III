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
        private readonly TpContext _context = new TpContext();
        private readonly ISessao _sessao;
        public VagasController(ISessao sessao)
        {
          _sessao = sessao; 
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            var tpContext = _context.Vagas.Include(v => v.PessoaJuridica);
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
                .Include(v => v.PessoaJuridica)
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
            ViewData["PessoaJuridicaId"] = new SelectList(_context.Empresas, "Id", "Id");
            ViewData["Tag"] = new SelectList(_context.Tags, "Id", "Label");
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Remuneracao,Curtidas,Turno,Modalidade,PessoaJuridicaId")] Vaga vaga)
        {
            Console.WriteLine("Entrou");
            StringValues listTags = Request.Form["VagasTags"];
            var empresa = _sessao.BuscarSessao("empLogado");
            vaga.PessoaJuridicaId = empresa.Id;
            vaga.Curtidas = 0;
            if (ModelState.IsValid)
            {
                _context.Add(vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                foreach (var idTag in listTags)
                {
                    int id = int.Parse(idTag);

                    Tag t = _context.Tags.FirstOrDefault(t => t.Id == id);
                    VagasTag vt = new VagasTag();
                    vt.TagId = t.Id;
                    vt.VagaId = vaga.Id;
                    
                    _context.Add(vt);
                    await _context.SaveChangesAsync();
                }

            }
           
            ViewData["PessoaJuridicaId"] = new SelectList(_context.Empresas, "Id", "Id", vaga.PessoaJuridicaId);
            return View(vaga);
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
            ViewData["PessoaJuridicaId"] = new SelectList(_context.Empresas, "Id", "Id", vaga.PessoaJuridicaId);
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Remuneracao,Curtidas,Turno,Modalidade,PessoaJuridicaId")] Vaga vaga)
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
            ViewData["PessoaJuridicaId"] = new SelectList(_context.Empresas, "Id", "Id", vaga.PessoaJuridicaId);
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
                .Include(v => v.PessoaJuridica)
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
