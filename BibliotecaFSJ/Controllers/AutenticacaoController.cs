using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return View(); 
        }
        
        public IActionResult Cadastro()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult LoginPost(LoginViewModel model)
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroViewModel model)
        {
            return View(); 
        }
    }
}
