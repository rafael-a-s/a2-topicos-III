using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PjA2Tp3.Models;
using System.Diagnostics;

namespace PjA2Tp3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly TpContext tp = new TpContext();

       

       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var tpContext = tp.Vagas.Include(v => v.PessoaJuridica);
            return View(await tpContext.ToListAsync());
        }
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}