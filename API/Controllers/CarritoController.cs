using BusinessLayer.Services;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;
        Response response = new();

        public CarritoController(ICarritoService service)
        {
            _carritoService = service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CarritoDeCompras(ProdCarritoDTO prodCarritoDTO, int IdUser)
        {
            response = await _carritoService.CarritoDeCompras(prodCarritoDTO, IdUser);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Factura(int idUsuario)
        {
            response = await _carritoService.Factura(idUsuario);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
