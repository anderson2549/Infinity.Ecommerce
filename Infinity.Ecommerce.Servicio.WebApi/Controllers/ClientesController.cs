using Microsoft.AspNetCore.Mvc;
using Infinity.Ecommerce.Aplicacion.DTO;
using Infinity.Ecommerce.Aplicacion.Inteface;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Infinity.Ecommerce.Servicio.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IClientesApplication _clientesApplication;

        public ClientesController(IClientesApplication clientesApplication)
        {
            _clientesApplication = clientesApplication;
        }

        #region "Metodo sincronos"
        [HttpPost]
        public IActionResult Insert(ClientesDto clientesDto)
        {
            if (clientesDto == null)
            {
                return BadRequest();
            }

            var response = _clientesApplication.Insert(clientesDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPut]
        public IActionResult Update(ClientesDto clientesDto)
        {
            if (clientesDto == null)
            {
                return BadRequest();
            }

            var response = _clientesApplication.Update(clientesDto);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpDelete()]
        
        public IActionResult Delete(string idCliente)
        {
            if (string.IsNullOrEmpty(idCliente))
            {
                return BadRequest();
            }

            var response = _clientesApplication.Delete(idCliente);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet()]
        public IActionResult Get(string idCliente)
        {
            if (string.IsNullOrEmpty(idCliente))
            {
                return BadRequest();
            }

            var response = _clientesApplication.get(idCliente);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _clientesApplication.GetAll();

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
        #endregion


    }
}
