using Dapper;
using QualificationApp.Domain.Base;
using QualificationApp.Domain.Dtos;
using QualificationApp.Domain.Entity;
using QualificationApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Domain.Interfaces.Parametro.Ocupacion
{
    public class OcupacionRepository: IOcupacionRepository
    {
        private readonly ConnectionDB _connectionDB;
        public OcupacionRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }
        public async Task<IEnumerable<OcupacionDto>> ObtenerTodos()
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var result = await connection.QueryAsync<OcupacionDto>("Maestro.usp_ListarOcupacion", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<OcupacionDto> ObtenerPorId(int idOcupacion)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdOcupacion", dbType: DbType.String, value: idOcupacion, direction: ParameterDirection.Input);
                var result = await connection.QueryAsync<OcupacionDto>("Maestro.usp_ListarOcupacion", param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<OcupacionDto>> Agregar(OcupacionModel o)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Descripcion", dbType: DbType.String, value: o.Descripcion, direction: ParameterDirection.Input);
                param.Add("@Estado", dbType: DbType.String, value: o.Estado, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: o.Usuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<OcupacionDto>>("Maestro.usp_CrearOcupacion", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<OcupacionDto>> Modificar(OcupacionModel o)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdOcupacion", dbType: DbType.Int32, value: o.IdOcupacion, direction: ParameterDirection.Input);
                param.Add("@Descripcion", dbType: DbType.String, value: o.Descripcion, direction: ParameterDirection.Input);
                param.Add("@Estado", dbType: DbType.String, value: o.Estado, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: o.Usuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<OcupacionDto>>("Maestro.usp_ModificarOcupacion", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<OcupacionDto>> Eliminar(int idOcupacion)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdOcupacion", dbType: DbType.Int32, value: idOcupacion, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<OcupacionDto>>("Maestro.usp_EliminarOcupacion", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
    }
}
