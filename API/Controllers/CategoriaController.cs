using BusinessLayer.Services;
using EntityLayer.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        Response response = new();

        public CategoriaController(ICategoriaService service)
        {
            _categoriaService = service;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RegistroCategoria(CategoriaDTO categoriaDTO)
        {
            response = await _categoriaService.RegistroCategoria(categoriaDTO);
            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
