using Dapper;
using QualificationApp.Domain.Base;
using QualificationApp.Domain.Dtos;
using QualificationApp.Domain.Entity;
using QualificationApp.Domain.Interfaces.Parametro.Pais;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Infrastructure.Repositories.Parametro.Pais
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ConnectionDB _connectionDB;
        public PaisRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }
        public async Task<IEnumerable<PaisDto>> ListarPaises()
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var result = await connection.QueryAsync<PaisDto>("Maestro.usp_ListarPais", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
       public async Task<PaisDto> ObtenerPaisPorId(int idPais)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdPais", dbType: DbType.String, value: idPais, direction: ParameterDirection.Input);
                var result = await connection.QueryAsync<PaisDto>("Maestro.usp_ListarPais", param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<PaisDto>> CrearPais(PaisModel p)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                //using(SqlTransaction transaction = connection.BeginTransaction())
                //{
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Nombre", dbType: DbType.String, value: p.Nombre, direction: ParameterDirection.Input);
                param.Add("@Abreviado", dbType: DbType.String, value: p.Abreviado, direction: ParameterDirection.Input);
                param.Add("@Gentilicio", dbType: DbType.String, value: p.Gentilicio, direction: ParameterDirection.Input);
                param.Add("@Estado", dbType: DbType.String, value: p.Estado, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: p.Usuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<PaisDto>>("Maestro.usp_CrearPais", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
                //}
            }
        }
        public async Task<RespuestaTransaction<PaisDto>> ModificarPais(PaisModel p)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdPais", dbType: DbType.Int32, value: p.IdPais, direction: ParameterDirection.Input);
                param.Add("@Nombre", dbType: DbType.String, value: p.Nombre, direction: ParameterDirection.Input);
                param.Add("@Abreviado", dbType: DbType.String, value: p.Abreviado, direction: ParameterDirection.Input);
                param.Add("@Gentilicio", dbType: DbType.String, value: p.Gentilicio, direction: ParameterDirection.Input);
                param.Add("@Estado", dbType: DbType.String, value: p.Estado, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: p.Usuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<PaisDto>>("Maestro.usp_ModificarPais", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<PaisDto>> EliminarPais(int idPais)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdPais", dbType: DbType.Int32, value: idPais, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<PaisDto>>("Maestro.usp_EliminarPais", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
 
    }
}
