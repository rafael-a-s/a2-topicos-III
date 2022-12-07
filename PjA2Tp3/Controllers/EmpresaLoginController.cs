using Microsoft.AspNetCore.Mvc;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;

namespace PjA2Tp3.Controllers
{
    public class EmpresaLoginController : Controller
    {
        private readonly TpContext _db;
        private readonly ISessao _sessao;


        public EmpresaLoginController(ISessao sessao, TpContext db)
        {
            _sessao = sessao;
            _db= db;
        }

        public IActionResult Login()
        {
            if (_sessao.BuscarSessao("empLogado") != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Valida")]
        public IActionResult Valida(string email, string password)
        {
            Console.WriteLine("Entrou");
            var empresa = _db.Empresas.Where(e => e.Email == email && e.Password == password && e.IsActive == true).FirstOrDefault();

            if (empresa != null)
            {
                _sessao.CriarSessaoDaEmpresa(empresa, "empLogado");
                _sessao.CriarSessaoParaNome(empresa.NomeFantasia, "usuNome");
               

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.msg = "Usuário ou senha inválidos";
                return RedirectToAction("Login", "EmpresaLogin");
            }
        }
    }
}
