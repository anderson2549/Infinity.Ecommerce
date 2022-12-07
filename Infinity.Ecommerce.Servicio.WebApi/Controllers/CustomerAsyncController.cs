using Infinity.Ecommerce.Aplicacion.Inteface;
using Microsoft.AspNetCore.Mvc;
using Infinity.Ecommerce.Aplicacion.DTO;

using System.Threading.Tasks;

namespace Infinity.Ecommerce.Servicio.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerAsyncController : Controller
    {

        private readonly ICustomersApplication _customersApplication;

        public CustomerAsyncController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }


        #region "metodos asyncronos"


        [HttpPost]
        public async Task<IActionResult> InsertAsync(CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }

            var response = await _customersApplication.InsertAsync(customersDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }

            var response = await _customersApplication.UpdateAsync(customersDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpDelete()]
        public async Task<IActionResult> DeleteAsync(string idCustomer)
        {
            if (string.IsNullOrEmpty(idCustomer))
            {
                return BadRequest();
            }

            var response = await _customersApplication.DeleteAsync(idCustomer);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet()]
        public async Task<IActionResult> GetAsync(string idCustomer)
        {
            if (string.IsNullOrEmpty(idCustomer))
            {
                return BadRequest();
            }

            var response = await _customersApplication.getAsync(idCustomer);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        #endregion
    }
}
