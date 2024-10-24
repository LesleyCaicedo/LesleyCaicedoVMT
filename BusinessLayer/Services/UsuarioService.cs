using DataLayer.Repository;
using EntityLayer.DTO;
using EntityLayer.Responses;


namespace BusinessLayer.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        Response Response = new Response();

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }


        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            Response = await _usuarioRepository.RegistroUsuario(usuarioDTO);
            return Response;
        }        

        public async Task<Response> InicioSesion(LoginDTO loginDTO)
        {
            Response = await _usuarioRepository.InicioSesion(loginDTO);
            return Response;
        }
    }
}
