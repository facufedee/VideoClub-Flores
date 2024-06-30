using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{ 
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool>Insertar(TEntityModel modelo);
        Task<bool>Actualizar(TEntityModel modelo);
        Task<bool>Eliminar(int id);
        Task<TEntityModel>ObtenerUno(int id);
        Task<IQueryable<TEntityModel>> ObtenerTodos();
    }
}
