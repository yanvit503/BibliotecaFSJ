using BibliotecaFSJ.Identity;
using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public AutenticacaoController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult Login()
        {
            if(_signManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _signManager.SignOutAsync(); 

            return RedirectToAction("Login", "Autenticacao");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmaEmail(string userId, string token)
        {
            var usuario = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(usuario, token);
            await _signManager.SignInAsync(usuario, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            throw new Exception(result.Errors.First().Description);
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(LoginViewModel model)
        {
            var usuario = await _userManager.FindByEmailAsync(model.Email);

            if (usuario == null)
            {
                TempData.Add("erro", "Nenhum usuário encontrado");
                return RedirectToAction("Login");
            }

            var resutl = await _signManager.PasswordSignInAsync(usuario, model.Senha, model.Persistente, false);

            if (!usuario.EmailConfirmed)
                TempData.Add("erro", "Confirme seu email para ter acesso");

            if (resutl.Succeeded)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Login");
        }

        public IActionResult EsqueciSenha()
        {
            return View();
        }

        public async Task<IActionResult> NovaSenha(string userId, string token)
        {
            var usuario = await _userManager.FindByIdAsync(userId);

            return View(new RecupercaoSenhaViewModel { Usuario = usuario.UserName, Token = token });
        }

        [HttpPost]
        public async Task<IActionResult> NovaSenha(RecupercaoSenhaViewModel model)
        {
            try
            {
                var usuario = await _userManager.FindByNameAsync(model.Usuario);

                var result = await _userManager.ResetPasswordAsync(usuario, model.Token, model.Senha);

                if (result.Succeeded)
                {
                    TempData.Add("info", "Sua senha foi alterada");
                    return RedirectToAction("Login", "Autenticacao");
                }

                TempData.Add("erro", result.Errors.First().Description);
                return View(new RecupercaoSenhaViewModel { Usuario = model.Usuario, Token = model.Token, Senha = model.Senha });
            }
            catch (Exception e)
            {
                TempData.Add("erro", e.Message);
                return View(new RecupercaoSenhaViewModel { Usuario = model.Usuario, Token = model.Token, Senha = model.Senha });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastroViewModel model)
        {
            if(await IdentityCadastro.CadastrarUsuario(_userManager, model, this))
                return RedirectToAction("Login");

            return BadRequest();
        }
    }
}
