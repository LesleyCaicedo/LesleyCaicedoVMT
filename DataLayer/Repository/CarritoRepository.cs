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
    public class CarritoRepository
    {
        private readonly LesleyCaicedoVmtContext _context;
        Response response = new Response();

        public CarritoRepository(LesleyCaicedoVmtContext context)
        {
            _context = context;
        }

        public async Task<Response> CarritoDeCompras(ProdCarritoDTO prodCarritoDTO)
        {

            var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.IdCarrito == prodCarritoDTO.IdCarrito);

            if (carrito == null)
            {
                response.Code = ResponseType.Error;
                response.Message = "Carrito no existe";

                return response;
            }


            //var producto = await _context.Productos.FirstOrDefaultAsync(c => c.IdProd == prodCarritoDTO.IdProducto);

            //if (producto == null)
            //{
            //    response.Code = ResponseType.Error;
            //    response.Message = "Producto no existe";

            //    return response;
            //}

            //ProdCarrito prodCarrito = new ProdCarrito()
            //{

            //}


        }
    }
}
