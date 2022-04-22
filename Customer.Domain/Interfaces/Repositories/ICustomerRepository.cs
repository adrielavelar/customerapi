using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customer.Domain.Entities;

namespace Customer.Domain.Interfaces.Repositories
{
	public interface ICustomerRepository
	{
		Task<CustomerEntity> Add(CustomerEntity customer);
		Task<bool> Delete(int id);
		Task<IEnumerable<CustomerEntity>> Get();
		Task<CustomerEntity> GetById(int id);
		Task<CustomerEntity> Update(CustomerEntity customer);
	}
}

