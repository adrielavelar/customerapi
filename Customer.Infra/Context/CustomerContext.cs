using System;
using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infra.Context
{
	public class CustomerContext : DbContext
	{
		public CustomerContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=CustomerDb;User Id=SA;Password=4dr13lAMARAL;TrustServerCertificate=true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}