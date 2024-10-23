using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IRegistroService
    {
        public Task<Response> RegistroUsuario(UsuarioDTO usuarioDTO);
        public Task<Response> RegistroCategoria(CategoriaDTO categoriaDTO);
        public Task<Response> IngresarProductos(ProductoDTO productoDTO);
        //public Task<Response> ListaDeProducto();
    }
}
