using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var obj = TopicoDAO.GetPaginaInicial().GroupBy(x => x.Id).Select(x => x.First()).ToList();

            return View(obj);
        }

        public IActionResult Pesquisa(string query)
        {
            var obj = TopicoDAO.GetPesquisa(query).GroupBy(x => x.Id).Select(x => x.First()).ToList();

            return View(obj);
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
