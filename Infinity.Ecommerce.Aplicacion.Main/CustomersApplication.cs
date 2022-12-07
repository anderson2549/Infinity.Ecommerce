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
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;

        public CustomersApplication(ICustomersDomain cusDom, IMapper mapper)
        {
            this._customersDomain = cusDom;
            this._mapper = mapper;
        }

        #region Metodos Sincronos
        public Response<bool> Insert(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customersDomain.Insert(customer);
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
        public Response<bool> Update(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = _customersDomain.Update(customer);
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
                response.Data = _customersDomain.Delete(customerId);
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
        public Response<CustomersDto> get(string customerId)
        {
            var response = new Response<CustomersDto>();

            try
            {
                var customer = _mapper.Map<CustomersDto>(_customersDomain.get(customerId));
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
        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();

            try
            {
                
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(_customersDomain.GetAll());
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
        public async Task<Response<bool>> InsertAsync(CustomersDto customerDto) {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.InsertAsync(customer);
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
        public async Task<Response<bool>> UpdateAsync(CustomersDto customerDto)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDto);
                response.Data = await _customersDomain.UpdateAsync(customer);
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
                response.Data = await _customersDomain.DeleteAsync(customerId);
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
        public async Task<Response<CustomersDto>> getAsync(string customerId)
        {
            var response = new Response<CustomersDto>();

            try
            {
                var customer = _mapper.Map<CustomersDto>( await _customersDomain.getAsync(customerId));
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
        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDto>>();

            try
            {

                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(await _customersDomain.GetAllAsync());
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
