using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IProductoRepository
    {
        public Task<Response> IngresarProductos(ProductoDTO productoDTO);
        public Task<Response> ListaDeProducto();
    }
}
