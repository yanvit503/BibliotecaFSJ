using BibliotecaFSJ.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFSJ.ControllersApi
{
    [Route("api/[controller]")]
    public class AutenticacaoApiController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public AutenticacaoApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        [HttpPost("EnviaRecuperacaoSenha/{email}")]
        public async Task<IActionResult> EnviaRecuperacaoSenha(string email)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(email);

                if (usuario == null)
                    return BadRequest("Nenhum usuário encontrado com " + email);

                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                EnviaEmailRecuperacao(email,token,usuario);

                return Ok("Email de recuperação enviado para " + email);
            }
            catch
            {
                return BadRequest("Ocorreu um erro");
            }
        }

        void EnviaEmailRecuperacao(string email,string token,IdentityUser usuario)
        {
            string urlCallback = Url.ActionLink("NovaSenha", "Autenticacao", new { userId = usuario.Id, token = token }, Request.Scheme);

            StringBuilder conteudoEmail = new StringBuilder();
            conteudoEmail.AppendLine(" Solicitou uma nova senha no sistema BibliotecaFsj ");
            conteudoEmail.AppendLine(" ");
            conteudoEmail.AppendLine(" Clique no link para mudar sua senha : " + urlCallback);

            EmailHelper.EnviaEmail(email, "Recuperação de senha", conteudoEmail.ToString(), true);
        }
    }
}
