using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ProdCarritoDTO
    {
        public List<int> IdProducto { get; set; }

        public int IdCarrito { get; set; }
    }
}
