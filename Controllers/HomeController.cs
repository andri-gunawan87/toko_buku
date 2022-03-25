using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Toko_Buku.Models;
using Toko_Buku.Services;
using System;
using System.IO;

namespace Toko_Buku.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataBukuService _dataBukuService;

        public HomeController(IDataBukuService dataBuku)
        {
            _dataBukuService = dataBuku;
        }

        public async Task<ActionResult> Index()
        {
            var data = await _dataBukuService.ReadViewModel();
            //return View(_dataBukuService.GetDataBukus());
            return View(data);
        }

        public IActionResult Add_Book()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Added(int id, string judul, int harga, string user)
        {
            //using (StreamWriter writer = new StreamWriter("database.txt", true))
            //{
            //        writer.Write("\n{0}, {1}, {2}, {3}", id, judul, harga, user);
            //}

            DataBuku dataBaru = new DataBuku(id, judul, harga, user);
            // _dataBukuService.AddData(dataBaru);
            _dataBukuService.Write(dataBaru);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
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