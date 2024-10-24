using DataLayer.Commons;
using EntityLayer.DTO;
using EntityLayer.Mappers;
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
    public class CarritoRepository : ICarritoRepository
    {
        private readonly LesleyCaicedoVmtContext _context;
        private readonly UsuarioMapper _usuarioMapper;

        Common idcommons = new Common();
        Response response = new Response();

        public CarritoRepository(LesleyCaicedoVmtContext context)
        {
            _context = context;
        }

        public async Task<Response> CarritoDeCompras(ProdCarritoDTO prodCarritoDTO,int IdUser)
        {
            try
            {
                
                var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.IdCarrito == prodCarritoDTO.IdCarrito && c.FkIdUser == IdUser);

                if (carrito == null || carrito.Estado != "A")
                {
                    int idCarrito = idcommons.maxCarrito() + 1;

                    Carrito nuevocarrito = new Carrito()
                    {
                        IdCarrito = idCarrito,
                        Estado = "A",
                        FkIdUser = IdUser,
                    };

                    prodCarritoDTO.IdCarrito = idCarrito;

                    await _context.Carritos.AddAsync(nuevocarrito);
                }


                foreach (int productos in prodCarritoDTO.IdProducto)
                {

                    int idProdC = idcommons.maxPCarrito() + 1;

                    Producto producto = _context.Productos.FirstOrDefault(c => c.IdProd == productos);

                    if (producto == null)
                    {
                        response.Code = ResponseType.Error;
                        response.Message = "Producto no existe";

                        return response;
                    }

                    ProdCarrito nuevoPCarrito = new ProdCarrito();
                    nuevoPCarrito.IdProdCar = idProdC;
                    nuevoPCarrito.FkIdCarrito = prodCarritoDTO.IdCarrito;
                    nuevoPCarrito.FkIdProd = productos;
                    nuevoPCarrito.Estado = "A";

                    await _context.ProdCarritos.AddAsync(nuevoPCarrito);
                    await _context.SaveChangesAsync();
                }


                response.Code = ResponseType.Success;
                response.Message = "Producto añadido al carrito";
                response.Data = prodCarritoDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "error";

                return response;
            }

        }

        public async Task<Response> Factura(int idUsuario)
        {
            try
            {
                Usuario usu = await _context.Usuarios.FindAsync(idUsuario);
                UsuarioDTO usuario = _usuarioMapper.UsuarioToUsuarioDTO(usu);
                response.Code = ResponseType.Success;
                response.Data = usuario;

            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "error";

                return response;
            }

            return response;
        }
    }
}
