using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{ 
    public interface IPeliculaService
    {
        Task<bool> Insertar(Pelicula modelo);
        Task<bool> Actualizar(Pelicula modelo);
        Task<bool> Eliminar(int id);
        Task<Pelicula> ObtenerUno(int id);
        Task<IQueryable<Pelicula>> ObtenerTodos();

        //Agregar cualquier otra funcionalidad que necesite el servicio
        Task<Pelicula>ObtenerPorNombre(string nombrePelicula);
    }
}
