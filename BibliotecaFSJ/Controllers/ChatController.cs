using BibliotecaFSJ.DAO.DAO;
using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Controllers
{
    public class ChatController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ChatController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> CaixaEntrada(string idUsuario)
        {
            var result = await MensagensDAO.GetConversasByUsuario(idUsuario);

            List<ConversaListaViewModel> model = new List<ConversaListaViewModel>();

            foreach(var conversa in result)
            {
                var ultimaMsg = conversa.Mensagens.OrderBy(x => x.Envio).LastOrDefault();

                model.Add(new ConversaListaViewModel
                {
                    Id = conversa.Id,
                    ConteudoUltimaMensagem = ultimaMsg.Conteudo,
                    DataUltimaMensagem = ultimaMsg.Envio.ToString("dd/MM/yyyy HH:mm"),
                    NomeUsuario = _userManager.FindByIdAsync(ultimaMsg.IdRemetente).Result.UserName
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Enviados(string idUsuario)
        {
            var result = await MensagensDAO.GetConversasEnviadasByUsuario(idUsuario);

            List<ConversaListaViewModel> model = new List<ConversaListaViewModel>();

            foreach(var conversa in result)
            {
                var ultimaMsg = conversa.Mensagens.OrderBy(x => x.Envio).LastOrDefault();

                model.Add(new ConversaListaViewModel
                {
                    Id = conversa.Id,
                    ConteudoUltimaMensagem = ultimaMsg.Conteudo,
                    DataUltimaMensagem = ultimaMsg.Envio.ToString("dd/MM/yyyy HH:mm"),
                    NomeUsuario = _userManager.FindByIdAsync(ultimaMsg.IdDestinatario).Result.UserName
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Mensagens(long idConversa)
        {
            List<MensagemListaViewModel> model = new List<MensagemListaViewModel>();

            var mensagens = await MensagensDAO.GetMensagensByConversa(idConversa);

            foreach (var msg in mensagens)
            {
                model.Add(new MensagemListaViewModel { 
                    Id = msg.Id,
                    ConteudoMensagem = msg.Conteudo,
                    IdConversa = msg.Conversa.Id,
                    IdRemetente = msg.IdRemetente,
                    DataMensagem = msg.Envio.ToString("dd/MM/yyyy mm:HH"),
                    NomeRemetente = _userManager.FindByIdAsync(msg.IdRemetente).Result.UserName
                });

                var queryDestinatario = mensagens.Where(x => x.IdRemetente != _userManager.GetUserId(User)).ToList();

                ViewBag.Destinatario = queryDestinatario.Count > 0 ? queryDestinatario.First().IdRemetente : null;

                if(ViewBag.Destinatario == null)
                {
                    queryDestinatario = mensagens.Where(x => x.IdDestinatario != _userManager.GetUserId(User)).ToList();

                    ViewBag.Destinatario = queryDestinatario.Count > 0 ? queryDestinatario.First().IdRemetente : null;
                }

                ViewBag.IdConversa = idConversa;
            }

            return View(model);
        }
    }
}