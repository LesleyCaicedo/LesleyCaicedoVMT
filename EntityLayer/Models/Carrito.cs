using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Carrito
{
    public int IdCarrito { get; set; }

    public string? Estado { get; set; }

    public int FkIdUser { get; set; }

    public virtual Usuario FkIdUserNavigation { get; set; } = null!;

    public virtual ICollection<ProdCarrito> ProdCarritos { get; set; } = new List<ProdCarrito>();
}
