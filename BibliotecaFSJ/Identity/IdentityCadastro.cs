using BibliotecaFSJ.Helper;
using BibliotecaFSJ.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Identity
{
    public static class IdentityCadastro
    {
        public static async Task<bool> CadastrarUsuario(UserManager<IdentityUser> userManager,CadastroViewModel model, Controller controller)
        {
            var usuario = new IdentityUser { Email = model.Email, UserName = model.Usuario, NormalizedUserName = model.Nome };

            var result = await userManager.CreateAsync(usuario, model.Senha);

            string token = await userManager.GenerateEmailConfirmationTokenAsync(usuario);

            string urlCallback = controller.Url.ActionLink("ConfirmaEmail","Autenticacao",new { userId = usuario.Id, token = token },controller.Request.Scheme);

            StringBuilder conteudoEmail = new StringBuilder();
            conteudoEmail.AppendLine(" Você criou sua conta no sistema BibliotecaFsj ");
            conteudoEmail.AppendLine(" ");
            conteudoEmail.AppendLine(" Clique no link para confirmar sua conta : " + urlCallback);

            if (result.Succeeded)
                EmailHelper.EnviaEmail(model.Email,"Confirmação de conta",conteudoEmail.ToString(),true);

            return true;
        }
    }
}
