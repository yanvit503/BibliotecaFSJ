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
        public async Task<Mensagem> EnviarMensagem(Mensagem mensagem)
        {
            await MensagensDAO.EnviaMensagem(mensagem);

            return mensagem;
        }
    }
}