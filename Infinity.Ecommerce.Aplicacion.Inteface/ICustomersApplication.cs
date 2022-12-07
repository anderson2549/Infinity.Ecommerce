using Infinity.Ecommerce.Aplicacion.DTO;
using Infinity.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infinity.Ecommerce.Aplicacion.Inteface
{
    public interface ICustomersApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(CustomersDto customerDto);
        Response<bool> Update(CustomersDto customerDto);
        Response<bool> Delete(string customerId);
        Response<CustomersDto> get(string customerId);
        Response<IEnumerable<CustomersDto>>  GetAll();
        #endregion


        #region Metodos Asincronos 
        Task<Response<bool>> InsertAsync(CustomersDto customerDto);
        Task<Response<bool>> UpdateAsync(CustomersDto customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDto>> getAsync(string customerId);
        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
        #endregion
    }
}
