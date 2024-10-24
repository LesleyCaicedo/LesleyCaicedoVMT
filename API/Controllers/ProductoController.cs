using API.Helpers;
using BusinessLayer.Services;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        Response response = new();

        public ProductoController(IProductoService service)
        {
            _productoService = service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IngresarProductos(ProductoDTO productoDTO)
        {
            response = await _productoService.IngresarProductos(productoDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> ListaDeProducto()
        {
            response = await _productoService.ListaDeProducto();
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
