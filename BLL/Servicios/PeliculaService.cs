using BE;
using DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{ 
    public class PeliculaService : IPeliculaService
    {
        public readonly IGenericRepository<Pelicula> _peliculaRepo;
        public PeliculaService(IGenericRepository<Pelicula> peliculaRepo)
        {
            _peliculaRepo = peliculaRepo;
        }
        public async Task<bool> Actualizar(Pelicula modelo)
        {
            return await _peliculaRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _peliculaRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Pelicula modelo)
        {
            return await _peliculaRepo.Insertar(modelo);
        }

        public async Task<Pelicula> ObtenerUno(int id)
        {
            return await _peliculaRepo.ObtenerUno(id);
        }

        public async Task<IQueryable<Pelicula>> ObtenerTodos()
        {
            return await _peliculaRepo.ObtenerTodos();
        }

        public async Task<Pelicula> ObtenerPorNombre(string nombrePelicula)
        {
            IQueryable<Pelicula> queryPeliculaSQL = await _peliculaRepo.ObtenerTodos();
            Pelicula pelicula = queryPeliculaSQL.Where(x => x.Nombre == nombrePelicula).FirstOrDefault();
            return pelicula;
        }

    }
}
