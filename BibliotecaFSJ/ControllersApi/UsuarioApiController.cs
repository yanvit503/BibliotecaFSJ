using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaFSJ.ControllersApi
{
    [Route("api/[controller]")]
    public class UsuarioApiController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetCombo")]
        public async Task<List<ComboResponse>> GetCombo(ComboRequest request)
        {
            List<ComboResponse> retorno = new List<ComboResponse>();

            var user = await _userManager.FindByNameAsync(request.Nome);

            if (user != null)
                retorno.Add(new ComboResponse { Id = user.Id, Nome = user.UserName });

            return retorno;
        }
    }

    public class ComboRequest
    {
        public string Nome { get; set; }
    }

    public class ComboResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
