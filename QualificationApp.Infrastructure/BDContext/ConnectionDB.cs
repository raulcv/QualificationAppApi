using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QualificationApp.Infrastructure
{
    public class ConnectionDB
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ConnectionDB(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("QualificationDBConnection");
        }
        public IDbConnection GetConnectionDB() => new SqlConnection(_connectionString);
    }
}
