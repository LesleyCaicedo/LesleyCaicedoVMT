using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUsuarioService
    {
        public Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO);
        public Task<Response> InicioSesion(LoginDTO loginDTO);
    }
}
