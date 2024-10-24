using DataLayer.Commons;
using EntityLayer.DTO;
using EntityLayer.Models;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        Response response = new();

        private readonly LesleyCaicedoVmtContext _context;
        Common idcommons = new Common();

        public CategoriaRepository(LesleyCaicedoVmtContext context)
        {
            _context = context;
        }

        public async Task<Response> RegistroCategoria(CategoriaDTO categoriaDTO)
        {
            try
            {
                int IdCat = idcommons.maxCat() + 1;

                Categorium nuevaCatgoria = new Categorium()
                {
                    IdCategoria = IdCat,
                    Nombre = categoriaDTO.Nombre,
                    Estado = "A",
                };

                await _context.Categoria.AddAsync(nuevaCatgoria);

                await _context.SaveChangesAsync();
                response.Code = ResponseType.Success;
                response.Message = "Categoria ingresada correctamente";
                response.Data = categoriaDTO;

                return response;

            }
            catch (Exception ex)
            {
                response.Code = ResponseType.Error;
                response.Message = "Error al registrar Categoria";
                response.Data = ex.Message;

                return response;
            }
        }
    }
}
