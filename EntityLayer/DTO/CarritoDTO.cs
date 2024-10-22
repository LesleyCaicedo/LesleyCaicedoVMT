using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class CarritoDTO
    {
        public int IdCarrito { get; set; }

        public int FkIdUser { get; set; }

        public List<ProdCarritoDTO> ProdCarritoModelo { get; set; }
    }
}
