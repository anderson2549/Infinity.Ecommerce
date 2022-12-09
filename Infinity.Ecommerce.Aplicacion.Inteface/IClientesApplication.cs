using Infinity.Ecommerce.Aplicacion.DTO;
using Infinity.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Infinity.Ecommerce.Aplicacion.Inteface
{
    public interface IClientesApplication
    {
        #region Metodos Sincronos
        Response<bool> Insert(ClientesDto customerDto);
        Response<bool> Update(ClientesDto customerDto);
        Response<bool> Delete(string customerId);
        Response<ClientesDto> get(string customerId);
        Response<IEnumerable<ClientesDto>> GetAll();
        #endregion


        #region Metodos Asincronos 
        Task<Response<bool>> InsertAsync(ClientesDto customerDto);
        Task<Response<bool>> UpdateAsync(ClientesDto customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<ClientesDto>> getAsync(string customerId);
        Task<Response<IEnumerable<ClientesDto>>> GetAllAsync();
        #endregion
    }
}
