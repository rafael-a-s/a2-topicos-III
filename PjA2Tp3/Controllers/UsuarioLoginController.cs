using Microsoft.AspNetCore.Mvc;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;
using System.Security.Cryptography.X509Certificates;

namespace PjA2Tp3.Controllers
{
    public class UsuarioLoginController : Controller
    {
        private readonly TpContext _db;
        private readonly ISessao _sessao;


        public UsuarioLoginController(ISessao sessao, TpContext db)
        {
            _sessao = sessao;
            _db = db;
        }
        public IActionResult Login()
        {
            if (_sessao.BuscarSessao("usuLogado") != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Valida")]
        public IActionResult Valida(string email, string password)
        {
            var user = _db.Usuarios.Where(u => u.Email == email && u.Password == password && u.IsActive == true).FirstOrDefault();
         
            if (user != null)
            {
                _sessao.CriarSessaoDoUsuario(user,"usuLogado");
                _sessao.CriarSessaoParaNome(user.Nome,"usuNome");
                _sessao.CriarSessaoPermissao( user.Perfil ,"permissao");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                ViewBag.msg = "Usuário ou senha inválidos";
                return RedirectToAction("Login", "UsuarioLogin");
            }
        }

       
    }
}

