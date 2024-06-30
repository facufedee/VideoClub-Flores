using System;
using BE;
using DAL.DataContext;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{ 
    public class PeliculaRepositorio : IGenericRepository<Pelicula>
    {
        private readonly VideoClubContext _dBVideoClub;
        public PeliculaRepositorio(VideoClubContext context)
        {
            _dBVideoClub = context;
        }
        public async Task<bool> Actualizar(Pelicula modelo)
        {
            _dBVideoClub.Peliculas.Update(modelo);
            await _dBVideoClub.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Pelicula modelo = _dBVideoClub.Peliculas.First(p => p.Id == id);
            _dBVideoClub.Peliculas.Remove(modelo);
            await _dBVideoClub.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Pelicula modelo)
        {
            _dBVideoClub.Peliculas.Add(modelo);
            await _dBVideoClub.SaveChangesAsync();
            return true;
        }

        public async Task<Pelicula> ObtenerUno(int id)
        {
            return await _dBVideoClub.Peliculas.FindAsync(id);
        }

        public async Task<IQueryable<Pelicula>> ObtenerTodos()
        {
            IQueryable<Pelicula> peliculas = _dBVideoClub.Peliculas;
            return peliculas;
        }
    }
}
