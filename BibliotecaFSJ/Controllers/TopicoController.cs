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
        public async Task<IActionResult> Exibir(int topicoId)
        {
            Topico topico = await TopicoDAO.GetById(topicoId);
            topico.Tags = TagDAO.GetByTopico(topicoId);

            CriarTopicoViewModel model = new CriarTopicoViewModel
            {
                Texto = topico.Texto,
                Titulo = topico.Titulo,
                Tags = new List<string>()
            };

            if(topico.Tags != null)
                topico.Tags.ToList().ForEach(x => { model.Tags.Add(x.Texto); });

            return View(model);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarTopicoViewModel model)
        {
            var imagens = Request.Form.Files.ToList();

            Topico topico = new Topico
            {
                Texto = model.Texto,
                Titulo = model.Titulo
            };

            var result = await TopicoDAO.Gravar(topico);

            List<Tag> tags = new List<Tag>();

            foreach (string tag in model.Tags)
            {
                tags.Add(new Tag { Texto = tag, TopicoId = topico.Id });
            }

            var resultTag = await TagDAO.Gravar(tags);

            if (result && resultTag)
                return Ok();

            return BadRequest();
        }
    }
}
