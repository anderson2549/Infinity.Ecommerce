using Infinity.Ecommerce.Aplicacion.DTO;
using Infinity.Ecommerce.Aplicacion.Inteface;
using Infinity.Ecommerce.Dominio.Entity;
using Infinity.Ecommerce.Dominio.Interface;
using Infinity.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System;
using System.Text.RegularExpressions;

namespace Infinity.Ecommerce.Aplicacion.Main
{
    public class ClientesApplication : IClientesApplication
    {

        private readonly IClientesDomain _clientesDomain;
        private readonly IMapper _mapper;

        public ClientesApplication(IClientesDomain cusDom, IMapper mapper)
        {
            this._clientesDomain = cusDom;
            this._mapper = mapper;
        }



        #region Metodos Sincronos
        public Response<bool> Insert(ClientesDto clienteDto)
        {
            var response = new Response<bool>();

            try
            {
                var validacion = this.validarDatos(clienteDto);
                if(!validacion.IsSuccess)
                {
                    response.IsSuccess = validacion.IsSuccess;
                    response.Message = validacion.Message;
                    return response;
                }
                var customer = _mapper.Map<Clientes>(clienteDto);
                response.Data = _clientesDomain.Insert(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Update(ClientesDto clienteDto)
        {
            var response = new Response<bool>();

            try
            {
                var validacion = this.validarDatos(clienteDto);
                if (!validacion.IsSuccess)
                {
                    response.IsSuccess = validacion.IsSuccess;
                    response.Message = validacion.Message;
                    return response;
                }
                var customer = _mapper.Map<Clientes>(clienteDto);
                response.Data = _clientesDomain.Update(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = _clientesDomain.Delete(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro borrado";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<ClientesDto> get(string customerId)
        {
            var response = new Response<ClientesDto>();

            try
            {
                var customer = _mapper.Map<ClientesDto>(_clientesDomain.get(customerId));
                response.Data = customer;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<IEnumerable<ClientesDto>> GetAll()
        {
            var response = new Response<IEnumerable<ClientesDto>>();

            try
            {

                response.Data = _mapper.Map<IEnumerable<ClientesDto>>(_clientesDomain.GetAll());
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion


        #region Metodos Asincronos 
        public async Task<Response<bool>> InsertAsync(ClientesDto clienteDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Clientes>(clienteDto);
                response.Data = await _clientesDomain.InsertAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(ClientesDto clienteDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Clientes>(clienteDto);
                response.Data = await _clientesDomain.UpdateAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();

            try
            {
                response.Data = await _clientesDomain.DeleteAsync(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro borrado";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<ClientesDto>> getAsync(string customerId)
        {
            var response = new Response<ClientesDto>();

            try
            {
                var customer = _mapper.Map<ClientesDto>(await _clientesDomain.getAsync(customerId));
                response.Data = customer;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;

        }
        public async Task<Response<IEnumerable<ClientesDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ClientesDto>>();

            try
            {

                response.Data = _mapper.Map<IEnumerable<ClientesDto>>(await _clientesDomain.GetAllAsync());
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<string> validarDatos(ClientesDto customerDto)
        {
            var response = new Response<string>();
            string mensaje = "";
            bool correoOK = customerDto.Correo != null && Regex.IsMatch(customerDto.Correo, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
            if (!correoOK) {
                mensaje += "<li type='circle'> Por favor validar correo\n";
            }

            //Validacion numero
            int valor;
            bool esNumero = int.TryParse((customerDto.Telefono!=null? customerDto.Telefono:"").Replace(" ",""), out valor);

            if (customerDto.Telefono!= null && customerDto.Telefono.Length<10 && esNumero|| customerDto.Telefono== null)
            {
                
                mensaje += "<li type='circle'> Por favor agregar un numero valido minimo 10 numeros\n";
            }

            if (customerDto.Cargo == null || customerDto.Cargo.Equals(""))
            {
                mensaje += "<li type='circle'> Por favor validar cargo\n";

            }
            if (customerDto.Nombres == null || customerDto.Nombres.Equals(""))
            {
                mensaje += "<li type='circle'> Por favor validar nombres\n";

            }
            if (customerDto.CodTipoClienteFK == null || customerDto.CodTipoClienteFK.Equals("") || customerDto.CodTipoClienteFK.Equals("0"))
            {
                mensaje += "<li type='circle'> Por favor validar tipo cliente\n";

            }
            if (customerDto.Usuario == null || customerDto.Usuario.Equals("") || customerDto.Usuario.Equals("0"))
            {
                mensaje += "<li type='circle'> Por favor validar Usuario\n";

            }

            if (mensaje.Equals("")) { 
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = mensaje;
            }



            return response;
        }
        #endregion






    }
}
