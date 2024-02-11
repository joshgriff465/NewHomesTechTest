using Microsoft.AspNetCore.Mvc;
using NewHomesTechTest.Models;
using System.Diagnostics;
using NewHomesTechTest.DataService.Interfaces;
using Newtonsoft.Json;

namespace NewHomesTechTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INumbers _numbers;


        public HomeController(ILogger<HomeController> logger, INumbers numbers)
        {
            _logger = logger;
            _numbers = numbers;

        }

        public IActionResult Index()
        {
            List<NumberModel> bleh = _numbers.Get().Result.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(NumberModel model)
        {
            model.Sum = calculation(model.NumberOne, model.NumberTwo);
            model.CreatedDate = DateTime.Now;
            var output = _numbers.Create(model);
            ViewBag.Sum = model.Sum;
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

        [HttpGet]
        public async Task<IActionResult> GetAllNumbers()
        {
            //Get all blogs from the database

            List<NumberModel> nums = await _numbers.Get();

            string json = JsonConvert.SerializeObject(nums);
            return Content(json, "application/json");

        }

        public decimal calculation(decimal numberOne, decimal numberTwo)
        {
            return numberOne + numberTwo;
        }
    }
}