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
    public partial class ProductoMapper
    {
        public partial Producto ProductoToProductoDTO(ProductoDTO productoDTO);

        public partial ProductoDTO ProductoToProductoDTO(Producto producto);
    }
}
