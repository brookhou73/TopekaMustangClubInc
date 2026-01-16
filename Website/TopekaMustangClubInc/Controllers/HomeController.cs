using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using TopekaMustangClubInc.Models;

namespace TopekaMustangClubInc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calendar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult History()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Mission()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Newsletter()
        {
            ViewBag.Month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            ViewBag.Year = DateTime.Now.Year.ToString();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        async Task SetBackView()
        {
            // Example of Task.Run Async
            await Task.Run(() =>
            {
                // Simulate a long-running task
                if (!String.IsNullOrEmpty(Request.Headers.Referer.ToString()))
                {
                    ViewData["Reffer"] = Request.Headers["Referer"].ToString();
                }
            });
        }
    }
}
