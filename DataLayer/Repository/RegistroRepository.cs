using DataLayer.Commons;
using EntityLayer.DTO;
using EntityLayer.Mappers;
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
    public class RegistroRepository : IRegistroRepository
    {
        Response response = new();
        
        private readonly LesleyCaicedoVmtContext _context;
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
                    Clave = EncryptHelper.ConvertToSha256(usuarioDTO.Clave!),
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

                await _context.Categoria.AddAsync(nuevaCatgoria);

                await _context.SaveChangesAsync();
                response.Code = ResponseType.Success;
                response.Message = "Categoria ingresada correctamente";
                response.Data= categoriaDTO;

                return response;

            } 
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar Categoria";
                response.Data = ex.Message;

                return response;
            }
        }
    
        public async Task<Response> IngresarProductos(ProductoDTO productoDTO)
        {
            try
            {
                int IdProd = idcommons.maxProd() + 1;

                Producto nuevoProducto = new Producto()
                {
                    IdProd = IdProd,
                    Nombre = productoDTO.Nombre,
                    Estado = "A",
                };

                await _context.Productos.AddAsync(nuevoProducto);

                await _context.SaveChangesAsync();
                response.Code = ResponseType.Success;
                response.Message = "Producto ingresado correctamente";
                response.Data = productoDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al ingresar Producto";
                response.Data = ex.Message; 
                
                return response;
            }
        }

        public async Task<Response> ListaDeProducto()
        {
            try
            {
                List<ListaDTO> listaProductos = new List<ListaDTO>();

                listaProductos = await _context.Categoria.Include(p => p.Productos).Select(c => new ListaDTO
                {
                    IdCategoria = c.IdCategoria,
                    NomCategoria = c.Nombre,
                    //Producto = _context.Productos.Select().ToList(),
                }).ToListAsync();

                response.Code = ResponseType.Success;
                response.Message = "Lista de productos por categorias";
                response.Data = listaProductos;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al mostrar lista de productos";
                response.Data = ex.Message;

                return response;
            }
        }
    }
}
