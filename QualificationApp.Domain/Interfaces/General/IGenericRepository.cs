using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Domain.Interfaces.General
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodos<T>();
        Task<T> ObtenerPorId(int id);
        Task<RespuestaTransaction<T>> Agregar(T entity);
        Task<RespuestaTransaction<T>> Modificar(T entity);
        Task<RespuestaTransaction<T>> Eliminar(int id);
    }
}
