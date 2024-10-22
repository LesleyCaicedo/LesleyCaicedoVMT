using DataLayer.Repository;
using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
