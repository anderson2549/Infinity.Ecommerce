using System;
using Infinity.Ecommerce.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Infinity.Ecommerce.Infraestructura.Data
{
    class ConnectionFactory : IConnectionFactory
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


                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");

                sqlConnection.Open();

                return sqlConnection;

            }
        }

    }
}
