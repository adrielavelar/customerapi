using System;
namespace Customer.Domain.Entities
{
	public class CustomerEntity
	{
		public CustomerEntity()
		{
		}

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}

