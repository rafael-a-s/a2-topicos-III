using Microsoft.AspNetCore.Mvc;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;
using System.Security.Cryptography.X509Certificates;

namespace PjA2Tp3.Controllers
{
    public class UsuarioLoginController : Controller
    {
        TpContext db = new TpContext();
        private readonly ISessao _sessao;


        public UsuarioLoginController(ISessao sessao)
        {
            _sessao = sessao;
        }
        public IActionResult Login()
        {
            if (_sessao.BuscarSessaoDoUsuario("usuLogado") != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Valida")]
        public IActionResult Valida(string email, string password)
        {
            var user = db.Usuarios.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
         
            if (user != null)
            {
                _sessao.CriarSessaoDoUsuario(user,"usuLogado");
                _sessao.CriarSessaoNomeUsuario(user.Nome,"usuNome");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                ViewBag.msg = "Usuário ou senha inválidos";
                return View();
            }
        }

       
    }
}

