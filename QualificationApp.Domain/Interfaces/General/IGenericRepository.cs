using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Domain.Interfaces.General
{
    public interface IGenericRepository<T,T1> where T : class where T1 : class
    {
        Task<IEnumerable<T1>> ObtenerTodos();
        Task<T1> ObtenerPorId(int id);
        Task<RespuestaTransaction<T1>> Agregar(T entity);
        Task<RespuestaTransaction<T1>> Modificar(T entity);
        Task<RespuestaTransaction<T1>> Eliminar(int id);
    }
}
