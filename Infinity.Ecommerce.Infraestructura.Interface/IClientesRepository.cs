using System;
using Infinity.Ecommerce.Dominio.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity.Ecommerce.Infraestructura.Interface
{
    public interface IClientesRepository
    {
        #region Metodos Sincronos
        bool Insert(Clientes cliente);
        bool Update(Clientes cliente);
        bool Delete(string CodClient);
        Clientes get(string CodClient);
        IEnumerable<Clientes> GetAll();
        #endregion


        #region Metodos Asincronos 
        Task<bool> InsertAsync(Clientes cliente);
        Task<bool> UpdateAsync(Clientes cliente);
        Task<bool> DeleteAsync(string CodClient);
        Task<Clientes> getAsync(string CodClient);
        Task<IEnumerable<Clientes>> GetAllAsync();
        #endregion
    }
}
