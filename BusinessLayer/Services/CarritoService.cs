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
    public class CarritoService : ICarritoService
    {
        private readonly ICarritoRepository _carritoRepository;

        Response Response = new Response();

        public CarritoService(ICarritoRepository repository)
        {
            _carritoRepository = repository;
        }


        public async Task<Response> CarritoDeCompras(ProdCarritoDTO prodCarritoDTO, int IdUser)
        {
            Response = await _carritoRepository.CarritoDeCompras(prodCarritoDTO, IdUser);
            return Response;
        }

        public async Task<Response> Factura(int idUsuario)
        {
            Response = await _carritoRepository.Factura(idUsuario);
            return Response;
        }
    }
}
