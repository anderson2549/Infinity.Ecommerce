using System;
using Infinity.Ecommerce.Dominio.Entity;
using Infinity.Ecommerce.Dominio.Interface;
using Infinity.Ecommerce.Infraestructura.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Infinity.Ecommerce.Dominio.Core
{
    public class ClientesDomain : IClientesDomain
    {

        private readonly IClientesRepository _clientesRepository;

        public ClientesDomain(IClientesRepository cus)
        {
            _clientesRepository = cus;
        }


        public bool Delete(string clienteId)
        {
            return _clientesRepository.Delete(clienteId);
        }

        public Task<bool> DeleteAsync(string clienteId)
        {
            return _clientesRepository.DeleteAsync(clienteId);
        }

        public Clientes get(string clienteId)
        {
            return _clientesRepository.get(clienteId);
        }

        public IEnumerable<Clientes> GetAll()
        {
            return _clientesRepository.GetAll();
        }

        public Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return _clientesRepository.GetAllAsync();
        }

        public Task<Clientes> getAsync(string clienteId)
        {
            return _clientesRepository.getAsync(clienteId);
        }

        public bool Insert(Clientes cliente)
        {
            return _clientesRepository.Insert(cliente);
        }

        public Task<bool> InsertAsync(Clientes cliente)
        {
            return _clientesRepository.InsertAsync(cliente);
        }

        public bool Update(Clientes cliente)
        {
            return _clientesRepository.Update(cliente);
        }

        public Task<bool> UpdateAsync(Clientes cliente)
        {
            return _clientesRepository.UpdateAsync(cliente);
        }
    }
}
