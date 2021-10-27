using BibliotecaFSJ.Helper;
using BibliotecaFSJ.Identity;
using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<IActionResult> Login()
        {
            return View(); 
        }
        
        public IActionResult Cadastro()
        {
            return View(); 
        }

        public async Task<IActionResult> ConfirmaEmail(string userId,string token)
        {
            var usuario = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(usuario,token);
            await _signManager.SignInAsync(usuario,false);

            if (result.Succeeded)
                return RedirectToAction("Index","Home");

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

            var resutl = await _signManager.PasswordSignInAsync(usuario,model.Senha,model.Persistente,false);

            if (!usuario.EmailConfirmed)
                TempData.Add("erro","Confirme seu email para ter acesso");

            if(resutl.Succeeded)
                return RedirectToAction("Index", "Home");


            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastroViewModel model)
        {
            await IdentityCadastro.CadastrarUsuario(_userManager,model,this);
            return RedirectToAction("Login"); 
        }       

    }
}
