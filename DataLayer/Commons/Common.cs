using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Commons
{
    public class Common
    {
        LesleyCaicedoVmtContext _context = new LesleyCaicedoVmtContext();

        public int maxUser()
        {
            int maxid = _context.Usuarios.Max(m => m.IdUser);
            return maxid;
        }

        public int maxProd()
        {
            int maxid = _context.Productos.Max(m => m.IdProd);
            return maxid;
        }

        public int maxCat()
        {
            int maxid = _context.Categoria.Max(m => m.IdCategoria);
            return maxid;
        }

        public int maxCarrito()
        {
            int maxid = _context.Carritos.Max(m => m.IdCarrito);
            return maxid;
        }

        public int maxPCarrito() 
        {
            int maxid = _context.ProdCarritos.Max(m => m.IdProdCar);
            return maxid;
        }

    }
}
