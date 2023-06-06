using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using zakharchenko_lab20.Models;

namespace zakharchenko_lab20.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CountLines(string inputText)
        {
            int lineCount = CountLinesInText(inputText);
            ViewBag.Result = "Кількість рядків: " + lineCount.ToString();
            return View("Index");
        }

        private int CountLinesInText(string inputText)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(inputText))
            {
                count = inputText.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;
            }
            return count;
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