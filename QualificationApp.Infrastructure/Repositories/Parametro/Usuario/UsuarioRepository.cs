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

namespace QualificationApp.Domain.Interfaces.Parametro.Usuario
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ConnectionDB _connectionDB;
        public UsuarioRepository(ConnectionDB connectionDB)
        {
            _connectionDB = connectionDB;
        }
        public async Task<IEnumerable<UsuarioDto>> ObtenerTodos()
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var result = await connection.QueryAsync<UsuarioDto>("Maestro.usp_ListarUsuario", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<UsuarioDto> ObtenerPorId(int idUsuario)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdUsuario", dbType: DbType.String, value: idUsuario, direction: ParameterDirection.Input);
                var result = await connection.QueryAsync<UsuarioDto>("Maestro.usp_ListarUsuario", param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<UsuarioDto>> Agregar(UsuarioModel u)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Nombre", dbType: DbType.String, value: u.Nombre, direction: ParameterDirection.Input);
                param.Add("@Apellido", dbType: DbType.String, value: u.Apellido, direction: ParameterDirection.Input);
                param.Add("@Imagen", dbType: DbType.String, value: u.Imagen, direction: ParameterDirection.Input);
                param.Add("@NombreUsuario", dbType: DbType.String, value: u.NombreUsuario, direction: ParameterDirection.Input);
                param.Add("@Email", dbType: DbType.String, value: u.Email, direction: ParameterDirection.Input);
                param.Add("@Password", dbType: DbType.String, value: u.Password, direction: ParameterDirection.Input);
                param.Add("@Estado", dbType: DbType.String, value: u.Estado, direction: ParameterDirection.Input);
                param.Add("@Salt", dbType: DbType.String, value: u.Salt, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: u.Usuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<UsuarioDto>>("Maestro.usp_CrearUsuario", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<UsuarioDto>> Modificar(UsuarioModel u)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdUsuario", dbType: DbType.String, value: u.IdUsuario, direction: ParameterDirection.Input);
                param.Add("@Nombre", dbType: DbType.String, value: u.Nombre, direction: ParameterDirection.Input);
                param.Add("@Apellido", dbType: DbType.String, value: u.Apellido, direction: ParameterDirection.Input);
                param.Add("@Imagen", dbType: DbType.String, value: u.Imagen, direction: ParameterDirection.Input);
                param.Add("@NombreUsuario", dbType: DbType.String, value: u.NombreUsuario, direction: ParameterDirection.Input);
                param.Add("@Email", dbType: DbType.String, value: u.Email, direction: ParameterDirection.Input);
                param.Add("@Password", dbType: DbType.String, value: u.Password, direction: ParameterDirection.Input);
                param.Add("@Estado", dbType: DbType.String, value: u.Estado, direction: ParameterDirection.Input);
                param.Add("@Salt", dbType: DbType.String, value: u.Salt, direction: ParameterDirection.Input);
                param.Add("@Usuario", dbType: DbType.String, value: u.Usuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<UsuarioDto>>("Maestro.usp_ModificarUsuario", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }
        public async Task<RespuestaTransaction<UsuarioDto>> Eliminar(int idUsuario)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@IdUsuario", dbType: DbType.String, value: idUsuario, direction: ParameterDirection.Input);
                var respuesta = await connection.QueryAsync<RespuestaTransaction<UsuarioDto>>("Maestro.usp_EliminarUsario", param, commandType: CommandType.StoredProcedure);
                return respuesta.FirstOrDefault();
            }
        }

        public async Task<UsuarioModel> ObtenerUsuarioPorEmail(string usuario)
        {
            using (var connection = _connectionDB.GetConnectionDB())
            {
                connection.Open();
                var param = new DynamicParameters();
                param.Add("@Usuario", dbType: DbType.String, value: usuario, direction: ParameterDirection.Input);
                var result = await connection.QueryAsync<UsuarioModel>("Maestro.usp_ObtenerUsuario", param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
    }
}
