using DataLayer;
using DataLayer.Repository;
using EntityLayer.DTO;
using EntityLayer.Mappers;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RegistroService : IRegistroService
    {

        private readonly IRegistroRepository _registroRepository;

        Response Response = new Response();

        public RegistroService(IRegistroRepository registro)
        {
            _registroRepository = registro;
        }


        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            Response = await _registroRepository.RegistroUsuario(usuarioDTO);
            return Response;
        }

        public async Task<Response> RegistroCategoria(CategoriaDTO categoriaDTO)
        {
            Response = await _registroRepository.RegistroCategoria(categoriaDTO);
            return Response;
        }

        public async Task<Response> IngresarProductos(ProductoDTO productoDTO)
        {
            Response = await _registroRepository.IngresarProductos(productoDTO);
            return Response;
        }

    }
}
