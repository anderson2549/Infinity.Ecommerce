using Microsoft.AspNetCore.Mvc;
using Infinity.Ecommerce.Aplicacion.DTO;
using Infinity.Ecommerce.Aplicacion.Inteface;
using System.Threading.Tasks;

namespace Infinity.Ecommerce.Servicio.WebApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region "Metodo sincronos"
        [HttpPost]
        public IActionResult Insert(CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }

            var response = _customersApplication.Insert(customersDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPut]
        public IActionResult Update(CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }

            var response = _customersApplication.Update(customersDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpDelete()]
        public IActionResult Delete(string idCustomer)
        {
            if (string.IsNullOrEmpty(idCustomer))
            {
                return BadRequest();
            }

            var response = _customersApplication.Delete(idCustomer);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet()]
        public IActionResult Get(string idCustomer)
        {
            if (string.IsNullOrEmpty(idCustomer))
            {
                return BadRequest();
            }

            var response = _customersApplication.get(idCustomer);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
        #endregion
     
        
    }
}
