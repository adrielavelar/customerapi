using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Domain.Entities;

namespace Customer.Domain.Interfaces.Services
{
	public interface ICustomerService
	{
		Task<CustomerEntity> Add(CustomerEntity customer);
		Task<bool> Delete(int id);
		Task<IEnumerable<CustomerEntity>> Get();
		Task<CustomerEntity> GetById(int id);
		Task<CustomerEntity> Update(CustomerEntity customer);
 	}
}