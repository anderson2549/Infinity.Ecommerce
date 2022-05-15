using Infinity.Ecommerce.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Infinity.Ecommerce.Infraestructura.Interface
{
    public interface ICustomersRepository
    {
        #region Metodos Sincronos
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);
        Customers get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion


        #region Metodos Asincronos 
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customers> getAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion

    }
}
