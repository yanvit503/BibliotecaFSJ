using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BibliotecaFSJ.ControllersApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatApiController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Mensagem>> EnviarMensagem(Mensagem mensagem)
        {
            try
            {
                await MensagensDAO.EnviaMensagem(mensagem);

                return StatusCode(200, mensagem);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}