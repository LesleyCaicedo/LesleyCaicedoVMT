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
    public partial class CarritoMapper
    {
        public partial Carrito CarritoToCarritoDTO(CarritoDTO carritoDTO);
        
        public partial CarritoDTO CarritoToCarritoDTO(Carrito carrito);

    }
}
