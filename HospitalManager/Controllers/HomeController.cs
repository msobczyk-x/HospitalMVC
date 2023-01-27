using HospitalManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HospitalManager.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HospitalManagerContext _context;

        public HomeController(HospitalManagerContext context)
        {
	        _context = context;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
	        var wizyty = _context.Wizyta;
			var wizytySort = (from z in wizyty
				where z.Data > DateTime.Now
				orderby z.Data
				select z);
			ViewBag.IloscWizyt = wizytySort.Count();
			return View();
        }



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}