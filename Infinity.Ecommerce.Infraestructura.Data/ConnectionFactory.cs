using System;
using Infinity.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Infinity.Ecommerce.Infraestructura.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration config)
        {
            _configuration = config;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();

                if (sqlConnection == null) return null;


                sqlConnection.ConnectionString = _configuration.GetConnectionString("GenericConex");

                sqlConnection.Open();

                return sqlConnection;

            }
        }

    }
}
