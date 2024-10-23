using BusinessLayer.Services;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _registroService.RegistroUsuario(usuarioDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroCategoria(CategoriaDTO categoriaDTO)
        {
            response = await _registroService.RegistroCategoria(categoriaDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IngresarProductos(ProductoDTO productoDTO)
        {
            response = await _registroService.IngresarProductos(productoDTO);
            if(response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}
