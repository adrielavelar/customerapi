using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await  _customerService.Get();

                if (customers.Any())
                {
                    return Ok(customers);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _customerService.GetById(id);

                if (customer is not null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerEntity entity)
        {
            try
            {
                var result = await _customerService.Add(entity);

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Sem sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerEntity entity)    
        {
            try
            {
                entity.Id = id;
                var result = await _customerService.Update(entity);

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Sem sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task< IActionResult> Delete(int id)
        {
            try
            {
                var success = await  _customerService.Delete(id);

                if (success)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Sem sucesso.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
