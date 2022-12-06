using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PjA2Tp3.Helper;
using PjA2Tp3.Models;
using System.Diagnostics;

namespace PjA2Tp3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly TpContext _db;

       

       

        public HomeController(ILogger<HomeController> logger, TpContext db)
        {
          _logger= logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _db.Vagas.Include(e => e.Empresas).ToListAsync());
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