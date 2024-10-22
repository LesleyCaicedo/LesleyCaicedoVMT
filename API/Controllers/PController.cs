using BusinessLayer.Services;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PController : ControllerBase
    {
        private readonly IRegistroService _registroService;
        Response response = new();

        public PController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        [HttpPost("[action]")]
        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _registroService.RegistroUsuario(usuarioDTO);
            return response;
        }

    }
}
