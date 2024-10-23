using DataLayer.Commons;
using EntityLayer.DTO;
using EntityLayer.Mappers;
using EntityLayer.Models;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class RegistroRepository : IRegistroRepository
    {
        Response response = new();
        
        private readonly LesleyCaicedoVmtContext _context;
        private readonly UsuarioMapper usuarioMapper;
        Common idcommons = new Common();

        public RegistroRepository(LesleyCaicedoVmtContext context)
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
                    Clave = usuarioDTO.Clave,
                    Correo = usuarioDTO.Correo,
                    Cedula = usuarioDTO.Cedula,
                    Estado = "A"
                };

                await _context.Usuarios.AddAsync(nuevoUsuario);

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

        public async Task<Response> RegistroCategoria(CategoriaDTO categoriaDTO)
        {
            try
            {
                int IdCat = idcommons.maxCat() + 1;

                Categorium nuevaCatgoria = new Categorium()
                {
                    IdCategoria = IdCat,
                    Nombre = categoriaDTO.Nombre,
                    Estado = "A",
                };







            } 
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar usuario";
                response.Data = ex.Message;

                return response;
            }
        }
    }
}
