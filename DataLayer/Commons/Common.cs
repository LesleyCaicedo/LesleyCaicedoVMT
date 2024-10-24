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
            int maxid = _context.Usuarios.Max(m => (int?)m.IdUser) ?? 0;
            return maxid;
        }

        public int maxProd()
        {
            int maxid = _context.Productos.Max(m => (int?)m.IdProd) ?? 0;
            return maxid;
        }

        public int maxCat()
        {
            int maxid = _context.Categoria.Max(m => (int?)m.IdCategoria) ?? 0;
            return maxid;
        }

        public int maxCarrito()
        {
            int maxid = _context.Carritos.Max(m => (int?)m.IdCarrito) ?? 0;
            return maxid;
        }

        public int maxPCarrito() 
        {
            int maxid = _context.ProdCarritos.Max(m => (int?)m.IdProdCar) ?? 0;
            return maxid;
        }

    }
}
