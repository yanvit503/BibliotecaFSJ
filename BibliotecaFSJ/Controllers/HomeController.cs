using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace BibliotecaFSJ.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
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
    }
}
