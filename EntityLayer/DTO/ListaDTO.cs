using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ListaDTO
    {
        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }
        public List<ProductoDTO> Producto  { get; set; }
    }
}
