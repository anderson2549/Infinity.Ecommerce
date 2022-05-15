using System;
using Infinity.Ecommerce.Dominio.Entity;
using Infinity.Ecommerce.Dominio.Interface;
using Infinity.Ecommerce.Infraestructura.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infinity.Ecommerce.Dominio.Core
{
    public class CustomersDomain : ICustomersDomain
    {

        private readonly ICustomersRepository _customersRepository;

        public CustomersDomain(ICustomersRepository cus)
        {
            _customersRepository = cus;
        }


        #region Metodos sincronos 

        public bool Insert(Customers customer)
        {
            return _customersRepository.Insert(customer);

        }


        public bool Update(Customers customer)
        {
            return _customersRepository.Update(customer);
        }



        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }


        public Customers get(string customerId)
        {
            return _customersRepository.get(customerId);
        }



        public IEnumerable<Customers> GetAll()
        {
            return _customersRepository.GetAll();
        }

        #endregion


        #region Metodos sincronos
        public Task<bool> DeleteAsync(string customerId)
        {
            return _customersRepository.DeleteAsync(customerId);
        }



        public Task<IEnumerable<Customers>> GetAllAsync()
        {
            return _customersRepository.GetAllAsync();
        }

        public Task<Customers> getAsync(string customerId)
        {
            return _customersRepository.getAsync(customerId);
        }


        public Task<bool> InsertAsync(Customers customer)
        {
            return _customersRepository.InsertAsync(customer);
        }


        public Task<bool> UpdateAsync(Customers customer)
        {
            return _customersRepository.UpdateAsync(customer);
        }

        #endregion
    }
}
