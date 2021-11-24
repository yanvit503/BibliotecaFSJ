using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Controllers
{
    public class ComentarioController : ControllerBase
    {
        [HttpPost]
        public async Task <IActionResult> Criar(Comentario comentario)
        {
            comentario.Horario = DateTime.Now;
            var result = await ComentarioDAO.SalvaComentario(comentario);

            if (result != null)
                return Ok(new { result.Id });

            return BadRequest();
        }
        
        [HttpPost]
        public async Task <IActionResult> Excluir(int id)
        {
            var result = await ComentarioDAO.ExcluirComentario(id);

            if (result)
                return Ok(new { id });

            return BadRequest();
        }
    }
}
