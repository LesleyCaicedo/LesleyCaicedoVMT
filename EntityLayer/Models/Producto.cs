using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Producto
{
    public int IdProd { get; set; }

    public string? Nombre { get; set; }

    public string? Estado { get; set; }

    public int FkIdCategoria { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public virtual Categorium FkIdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<ProdCarrito> ProdCarritos { get; set; } = new List<ProdCarrito>();
}
