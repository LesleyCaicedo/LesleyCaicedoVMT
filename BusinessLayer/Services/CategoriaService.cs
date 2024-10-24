using DataLayer.Repository;
using EntityLayer.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        Response Response = new Response();

        public CategoriaService(ICategoriaRepository repository)
        {
            _categoriaRepository = repository;
        }

        public async Task<Response> RegistroCategoria(CategoriaDTO categoriaDTO)
        {
            Response = await _categoriaRepository.RegistroCategoria(categoriaDTO);
            return Response;
        }
    }
}
