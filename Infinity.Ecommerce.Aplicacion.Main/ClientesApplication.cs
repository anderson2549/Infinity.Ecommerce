using Infinity.Ecommerce.Aplicacion.DTO;
using Infinity.Ecommerce.Aplicacion.Inteface;
using Infinity.Ecommerce.Dominio.Entity;
using Infinity.Ecommerce.Dominio.Interface;
using Infinity.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System;
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
        #endregion






    }
}
