using Microsoft.AspNetCore.Mvc;

namespace BibliotecaFSJ.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult CaixaEntrada()
        {
            return View();
        }
        public IActionResult Mensagens()
        {
            return View();
        }
    }
}
