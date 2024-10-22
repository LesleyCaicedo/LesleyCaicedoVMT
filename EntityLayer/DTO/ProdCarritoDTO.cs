using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ProdCarritoDTO
    {
        public int IdProdCar { get; set; }

        public string? Estado { get; set; }

        public int FkIdProd { get; set; }

        public int FkIdCarrito { get; set; }
    }
}
