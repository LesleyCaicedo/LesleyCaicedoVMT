using EntityLayer.DTO;
using EntityLayer.Models;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Mappers
{
    [Mapper]
    public partial class UsuarioMapper
    {
        public partial Usuario UsuarioToUsuarioDTO(UsuarioDTO usuarioDTO);

        public partial UsuarioDTO UsuarioToUsuarioDTO(Usuario usuario);
    }
}
