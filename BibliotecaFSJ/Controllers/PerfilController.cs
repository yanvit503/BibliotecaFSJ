using BibliotecaFSJ.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BibliotecaFSJ.Controllers
{
    public class PerfilController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public PerfilController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MinhaConta(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var usuario = await _userManager.FindByIdAsync(id);

            var model = new ContaViewModel()
            {
                Id = id,
                Nome = usuario.NormalizedUserName,
                Usuario = usuario.UserName,
                Email = usuario.Email
            };

            if (TempData["msg"] != null)
                ViewBag.Msg = TempData["msg"];

            return View(model);
        } 
        
        [HttpPost]
        public async Task<IActionResult> MinhaConta(ContaViewModel model, IFormFile file)
        {
            var usuario = await _userManager.FindByIdAsync(model.Id);

            if (usuario == null)
                return NotFound();

            usuario.Email = model.Email;
            usuario.UserName = model.Usuario;
            usuario.NormalizedUserName = model.Nome;

            await _userManager.UpdateAsync(usuario);

            if(file != null) 
                await SalvaFoto(usuario.Id,file);

            TempData["msg"] = "Perfil atualizado";
            return RedirectToAction("MinhaConta", new { id = model.Id });
        }

        async Task<bool> SalvaFoto(string userId, IFormFile file)
        {
            try
            {
                var fileName = userId + "." + file.FileName.Split('.')[1];
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Imagens\User", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
