using Dapper;
using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QualificationApp.Infrastructure.Repositories.General
{
    public class ExceptionLogRepository
    {
        private readonly ConnectionDB _connectionDB;
        public ExceptionLogRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }
        public async Task<int> registrarExcepcion(string host, string url, string mensaje, string usuario)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Host", dbType: DbType.String, value: host, direction: ParameterDirection.Input);
                param.Add("@Url", dbType: DbType.String, value: url, direction: ParameterDirection.Input);
                param.Add("@Mensaje", dbType: DbType.String, value: mensaje, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: usuario, direction: ParameterDirection.Input);
                var id = await connection.QueryFirstOrDefaultAsync<int>("Auditoria.usp_RegistrarAuditoria", param, commandType: CommandType.StoredProcedure);
                return Int32.Parse(id.ToString());
            }
        }
    }
}
