using Diploma_v1._1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ApplicationDb;

namespace Diploma_v1._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Diploma_v1_1Context _context;


        public HomeController(ILogger<HomeController> logger, Diploma_v1_1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsList.ToListAsync());
        }

        public async Task<IActionResult> OnePage(int? id)
        {
            if (id == null || _context.NewsList == null)
            {
                return NotFound();
            }

            var news = await _context.NewsList.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        public async Task<IActionResult> Category(string categotyName)
        {
            ViewBag.Message = categotyName;
            return View(await _context.NewsList.Where(x => x.Category.Equals(categotyName)).ToListAsync());
        }

        public IActionResult ContactUs()
        {
            return View();
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