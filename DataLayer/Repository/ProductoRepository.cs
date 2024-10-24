using DataLayer.Commons;
using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        Response response = new();

        private readonly LesleyCaicedoVmtContext _context;
        Common idcommons = new Common();

        public ProductoRepository(LesleyCaicedoVmtContext context)
        {
            _context = context;
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
                    FkIdCategoria = productoDTO.IdCategoria,
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
                    Producto = c.Productos.Select(p => new ProductoDTO
                    {
                        IdProd = p.IdProd,
                        Nombre = p.Nombre,
                    }).ToList(),
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
