using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TrafficManagement.Models;

namespace TrafficManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrafficDbContext _context;

        public HomeController(ILogger<HomeController> logger, TrafficDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
                if(!user.UserName.IsNullOrEmpty() && !user.Password.IsNullOrEmpty())
                {
                    if (_context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault() != null)
                    {
       
                        HttpContext.Session.SetString("User", "Shashi");
                        return RedirectToAction("Index");
                    }
                    ViewBag.Mes = "Invalid Login attempt";
                    return View();
                }
                ViewBag.Mes = "Please Enter the Required Field.";
                return View();
            }
            catch (Exception ex)
            {
                throw ex; 
            }

        }
        
        public IActionResult GeneralSetting()
        {
            General general = new General();
            var value = _context.Generals.FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public IActionResult GeneralSetting(General general)
        {
            _context.Generals.Update(general);
            _context.SaveChanges();
            return View();
        }

        public IActionResult Analyzer()
        {
            General general = new General();
            var value = _context.Generals.FirstOrDefault();
            return View(value);
        }

        //[HttpPost]
        //public IActionResult Analyzer()
        //{
        //    return View();
        //}
        public IActionResult ErrorPage()
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