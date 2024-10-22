using EntityLayer.DTO;
using EntityLayer.Models;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Mappers
{
    [Mapper]
    public partial class ProdCarritoMapper
    {
        public partial ProdCarrito PCarritoToPCarritoDTO(ProdCarritoDTO prodCarritoDTO);

        public partial ProdCarritoDTO PCarritoToPCarritoDTO(ProdCarrito prodCarrito);
    }
}
