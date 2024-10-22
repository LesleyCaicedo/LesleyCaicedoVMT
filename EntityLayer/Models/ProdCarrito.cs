using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class ProdCarrito
{
    public int IdProdCar { get; set; }

    public string? Estado { get; set; }

    public int FkIdProd { get; set; }

    public int FkIdCarrito { get; set; }

    public virtual Carrito FkIdCarritoNavigation { get; set; } = null!;

    public virtual Producto FkIdProdNavigation { get; set; } = null!;
}
