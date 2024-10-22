using System;
using System.Collections.Generic;

namespace EntityLayer.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Nombre { get; set; }

    public string? Alias { get; set; }

    public string? Clave { get; set; }

    public string? Correo { get; set; }

    public string? Cedula { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();
}
