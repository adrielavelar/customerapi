using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Repositories;
using Customer.Domain.Interfaces.Services;

namespace Customer.Domain.Services
{
	public class CustomerService : ICustomerService
	{
        private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
            _customerRepository = customerRepository;
		}

        public async Task<CustomerEntity> Add(CustomerEntity customer)
        {
          return await  _customerRepository.Add(customer);
        }

        public async Task<bool> Delete(int id)
        {
            return await _customerRepository.Delete(id);
        }

        public async Task<IEnumerable<CustomerEntity>> Get()
        {
            return await _customerRepository.Get();
        }

        public async Task<CustomerEntity> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task<CustomerEntity> Update(CustomerEntity customer)
        {
            return await _customerRepository.Update(customer);
        }
    }
}

