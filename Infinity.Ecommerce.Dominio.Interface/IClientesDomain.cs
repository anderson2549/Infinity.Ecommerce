using Infinity.Ecommerce.Dominio.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infinity.Ecommerce.Dominio.Interface
{
    public interface IClientesDomain
    {
        #region Metodos Sincronos
        bool Insert(Clientes cliente);
        bool Update(Clientes cliente);
        bool Delete(string clienteId);
        Clientes get(string clienteId);
        IEnumerable<Clientes> GetAll();
        #endregion


        #region Metodos Asincronos 
        Task<bool> InsertAsync(Clientes cliente);
        Task<bool> UpdateAsync(Clientes cliente);
        Task<bool> DeleteAsync(string clienteId);
        Task<Clientes> getAsync(string clienteId);
        Task<IEnumerable<Clientes>> GetAllAsync();
        #endregion
    }
}
