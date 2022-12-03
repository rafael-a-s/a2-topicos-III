using Microsoft.AspNetCore.Mvc;

namespace PjA2Tp3.Controllers
{
    public class UsuarioLoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
