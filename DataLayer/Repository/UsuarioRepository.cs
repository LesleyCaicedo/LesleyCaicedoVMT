using DataLayer.Commons;
using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using EntityLayer.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Response response = new();
        
        private readonly LesleyCaicedoVmtContext _context;
        Common idcommons = new Common();

        public UsuarioRepository(LesleyCaicedoVmtContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO)
        {
            try
            {
                int IdUser = idcommons.maxUser() + 1;

                Usuario nuevoUsuario = new Usuario()
                {
                    IdUser = IdUser,
                    Nombre = usuarioDTO.Nombre,
                    Alias = usuarioDTO.Alias,
                    Clave = EncryptHelper.ConvertToSha256(usuarioDTO.Clave!),
                    Correo = usuarioDTO.Correo,
                    Cedula = usuarioDTO.Cedula,
                    Estado = "A"
                };

                await _context.Usuarios.AddAsync(nuevoUsuario);

                int idCarrito = idcommons.maxCarrito() + 1;

                Carrito nuevocarrito = new Carrito() 
                {
                    IdCarrito = idCarrito,
                    Estado = nuevoUsuario.Estado,
                    FkIdUser = nuevoUsuario.IdUser,
                };

                await _context.Carritos.AddAsync(nuevocarrito);
                await _context.SaveChangesAsync();

                response.Code = ResponseType.Success;
                response.Message = "Usuario Registrado";
                response.Data = usuarioDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar usuario";
                response.Data = ex.Message;

                return response;
            }         

        }

        public async Task<Response> InicioSesion(LoginDTO loginDTO)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Alias.Equals(loginDTO.Username) && x.Clave.Equals(EncryptHelper.ConvertToSha256(loginDTO.Password)));

            if (usuario == null) { 
                response.Code = ResponseType.Error;
                response.Message = "Usuario no existe o clave incorrecta";

                return response;
            }

            response.Code = ResponseType.Success;
            response.Message = "Sesion iniciada";
            response.Data = usuario;

            return response;

        }
    }
}
