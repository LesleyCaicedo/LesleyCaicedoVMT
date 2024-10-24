using API.Helpers;
using BusinessLayer.Services;
using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AuthHelper _authHelper;
        Response response = new();

        public UsuarioController(IUsuarioService service, IConfiguration configuration)
        {
            _usuarioService = service;
            _authHelper = new AuthHelper(configuration);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _usuarioService.RegistroUsuario(usuarioDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }        

        [HttpPost("[action]")]
        public async Task<IActionResult> InicioSesion(LoginDTO loginDTO)
        {
            response = await _usuarioService.InicioSesion(loginDTO);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            Usuario usuario = (Usuario)response.Data;
            string token = _authHelper.GenerateJWTToken(usuario.Nombre,usuario.Cedula,usuario.Correo);

            return Ok(new { token = token });
        }
    }
}
