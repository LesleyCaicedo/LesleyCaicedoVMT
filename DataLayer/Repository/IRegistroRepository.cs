using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IRegistroRepository
    {
        public Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO);
        public Task<Response> RegistroCategoria(CategoriaDTO categoriaDTO);
        public Task<Response> IngresarProductos(ProductoDTO productoDTO);
    }
}
