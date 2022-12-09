using System;
using Infinity.Ecommerce.Dominio.Entity;
using Infinity.Ecommerce.Infraestructura.Interface;
using Infinity.Ecommerce.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infinity.Ecommerce.Infraestructura.Repository
{
    public class ClientesRepository: IClientesRepository
    {

        private readonly IConnectionFactory _connectionFactory;


        public ClientesRepository(IConnectionFactory con)
        {
            _connectionFactory = con;
        }

        #region Metodos sincronos


        public bool Insert(Clientes cliente)
        {
            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesInsert";
                var parameters = new DynamicParameters();
                /*


                @CodClient int,
                @Usuario varchar(50),
                @Nombres varchar(255),
                @Cargo varchar(100),
                @Telefono varchar(20),
                @Correo varchar(100),
                @CodTipoClienteFK int*/
                //parameters.Add("CodClient", customers.CodClient);
                parameters.Add("Usuario", cliente.Usuario);
                parameters.Add("Nombres", cliente.Nombres);
                parameters.Add("Cargo", cliente.Cargo);
                parameters.Add("Telefono", cliente.Telefono);
                parameters.Add("Correo", cliente.Correo);
                parameters.Add("CodTipoClienteFK", cliente.CodTipoClienteFK);

                var result = con.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }


        }


        public bool Update(Clientes cliente)
        {

            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CodClient", cliente.CodClient);
                parameters.Add("Usuario", cliente.Usuario);
                parameters.Add("Nombres", cliente.Nombres);
                parameters.Add("Cargo", cliente.Cargo);
                parameters.Add("Telefono", cliente.Telefono);
                parameters.Add("Correo", cliente.Correo);
                parameters.Add("CodTipoClienteFK", cliente.CodTipoClienteFK);


                var result = con.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }

        }


        public bool Delete(string CodClient)
        {

            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CodClient", CodClient);

                var result = con.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }

        }

        public Clientes get(string CodClient)
        {
            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CodClient", CodClient);

                var customer = con.QuerySingle<Clientes>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        public IEnumerable<Clientes> GetAll()
        {

            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesList";
                var customers = con.Query<Clientes>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        #endregion


        #region Metodos Asincronos


        public async Task<bool> DeleteAsync(string CodClient)
        {

            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CodClient", CodClient);

                var result = await con.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }


        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {

            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesList";
                var customers = await con.QueryAsync<Clientes>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

        public async Task<Clientes> getAsync(string CodClient)
        {
            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CodClient", CodClient);

                var customer = await con.QuerySingleAsync<Clientes>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return customer;
            }
        }

        public async Task<bool> InsertAsync(Clientes cliente)
        {
            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Usuario", cliente.Usuario);
                parameters.Add("Nombres", cliente.Nombres);
                parameters.Add("Cargo", cliente.Cargo);
                parameters.Add("Telefono", cliente.Telefono);
                parameters.Add("Correo", cliente.Correo);
                parameters.Add("CodTipoClienteFK", cliente.CodTipoClienteFK);

                var result = await con.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }


        public async Task<bool> UpdateAsync(Clientes cliente)
        {
            using (var con = _connectionFactory.GetConnection)
            {
                var query = "ClientesInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CodClient", cliente.CodClient);
                parameters.Add("Usuario", cliente.Usuario);
                parameters.Add("Nombres", cliente.Nombres);
                parameters.Add("Cargo", cliente.Cargo);
                parameters.Add("Telefono", cliente.Telefono);
                parameters.Add("Correo", cliente.Correo);
                parameters.Add("CodTipoClienteFK", cliente.CodTipoClienteFK);

                var result = await con.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
        #endregion

    }
}
