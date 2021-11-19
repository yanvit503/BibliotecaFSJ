using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.Models;
using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Controllers
{
    public class TopicoController : Controller
    {
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarTopicoViewModel model)
        {
            var a = Request.Form.Files;

            Topico topico = new Topico
            {
                Texto = model.Texto,
                Titulo = model.Titulo
            };

            var result = await TopicoDAO.Gravar(topico);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
