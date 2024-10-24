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
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        Response Response = new Response();

        public ProductoService(IProductoRepository repository)
        {
            _productoRepository = repository;
        }

        public async Task<Response> IngresarProductos(ProductoDTO productoDTO)
        {
            Response = await _productoRepository.IngresarProductos(productoDTO);
            return Response;
        }

        public async Task<Response> ListaDeProducto()
        {
            Response = await _productoRepository.ListaDeProducto();
            return Response;
        }
    }
}
