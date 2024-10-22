﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        public string? Nombre { get; set; }

        public string? Estado { get; set; }

        public List<ProductoDTO> ProductosModelo { get; set; }
    }
}
