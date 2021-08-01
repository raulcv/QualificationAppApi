using QualificationApp.Domain.Base;
using QualificationApp.Domain.Dtos;
using QualificationApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Domain.Interfaces.Parametro.Pais
{
    public interface IPaisRepository
    {
        public Task<IEnumerable<PaisDto>> ListarPaises();
        public Task<PaisDto> ObtenerPaisPorId(int idPais);
        public Task<RespuestaTransaction<PaisDto>> CrearPais(PaisModel pais);
        public Task<RespuestaTransaction<PaisDto>> ModificarPais(PaisModel pais);
        public Task<RespuestaTransaction<PaisDto>> EliminarPais(int idPais);
    }
}
