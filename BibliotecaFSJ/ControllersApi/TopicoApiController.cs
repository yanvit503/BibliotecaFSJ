using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.Models;
using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.ControllersApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicoApiController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Criar(TopicoViewModel model)
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

            //depois de gravar o topico e as tags, grava as imagens
            var resultFoto = await SalvaFoto(topico.Id, imagens);

            if (result && resultTag && resultFoto)
                return Ok(topico.Id);

            return BadRequest();
        }

        async Task<bool> SalvaFoto(int topicoId, List<IFormFile> files)
        {
            try
            {
                int i = 0;
                List<TopicoImagens> objs = new List<TopicoImagens>();

                foreach (var file in files)
                {
                    var fileName = topicoId + i + "." + file.FileName.Split('.')[1];
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Imagens\Topico", topicoId.ToString()));
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Imagens\Topico", topicoId.ToString(), fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);


                        objs.Add(new TopicoImagens { TopicoId = topicoId, Url = Path.Combine(@"\Imagens\Topico", topicoId.ToString(), fileName) });
                    }
                    i++;
                }

                return await ImagemTopicoDAO.SalvarImagensTopico(objs);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
