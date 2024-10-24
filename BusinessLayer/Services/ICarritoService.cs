using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICarritoService
    {
        public Task<Response> CarritoDeCompras(ProdCarritoDTO prodCarritoDTO, int IdUser);
        public Task<Response> Factura(int idUsuario);
    }
}
