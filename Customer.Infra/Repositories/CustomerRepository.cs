using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Repositories;
using Customer.Infra.Context;

namespace Customer.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }

        public async Task<CustomerEntity> Add(CustomerEntity customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = context.Customers.FirstOrDefault(x => x.Id == id);
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CustomerEntity>> Get()
        {
            return context.Customers.AsQueryable().ToList();
        }

        public async Task<CustomerEntity> GetById(int id)
        {
            return await Task.FromResult(context.Customers.FirstOrDefault(x => x.Id == id)).ConfigureAwait(false);
        }

        public async Task<CustomerEntity> Update(CustomerEntity customer)
        {
            var result = context.Customers.FirstOrDefault(x => x.Id == customer.Id);

            if (result is not null)
            {
                result.Name = customer.Name;
                result.Date = customer.Date;

                await context.SaveChangesAsync();
            }

            return customer;
        }
    }
}

