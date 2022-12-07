using Microsoft.AspNetCore.Mvc;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;

namespace PjA2Tp3.Controllers
{
    public class LoginController : Controller
    {

        private readonly ISessao _sessao;
        public LoginController(ISessao sessao)
        {
            _sessao= sessao;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        public IActionResult Logout()
        {
            _sessao.RemoverSessao("usuLogado");
            _sessao.RemoverSessao("usuNome");
            _sessao.RemoverSessao("empLogado");

            return RedirectToAction("Index", "Home");
        }

    }
    
}
