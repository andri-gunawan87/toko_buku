using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Toko_Buku.Models;

namespace Toko_Buku.Controllers
{
    public class HomeController : Controller
    {
        List<databuku> _listBuku = new List<databuku>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _listBuku = new List<databuku>() { 
                new databuku("Cara Memasak", 10000), 
                new databuku("Cara Membuat Rumah", 12000),
                new databuku("Easy Streaming", 22500),
                new databuku("Google Analytic", 17200)
                };

        }

        public IActionResult Index()
        {
            Console.WriteLine(_listBuku.Count);
            return View(_listBuku);
        }

        public IActionResult Add_Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Added(string judul, int harga)
        {
            //_listBuku.Add(new databuku(judul, harga));
            //databuku dataBaru = new databuku(judul, harga);
            //_listBuku.Add(dataBaru);
            _listBuku.Add(new databuku(judul, harga));

            return View(_listBuku);
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