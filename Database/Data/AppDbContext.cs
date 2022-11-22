using Microsoft.EntityFrameworkCore;
using WDD.Data.Entities;

namespace WDD.Data
{
    public class AppDbContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public AppDbContext()
		{			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Contact>().HasData(
				new Contact()
				{
					Id = 1,
					FirstName = "Eric",
					LastName = "Elliot",
					PhoneNumber = "222-555-6575"
				},
				new Contact()
				{
					Id = 2,
					FirstName = "Steve",
					LastName = "Jobs",
					PhoneNumber = "220-454-6754"
				},
				new Contact()
				{
					Id = 3,
					FirstName = "Fred",
					LastName = "Allen",
					PhoneNumber = "210-657-9886"
				},
				new Contact()
				{
					Id = 4,
					FirstName = "Steve",
					LastName = "Woznaik",
					PhoneNumber = "343-675-8786"
				},
				new Contact()
				{
					Id = 5,
					FirstName = "Bill",
					LastName = "Gates",
					PhoneNumber = "343-654-9688"
				});
		}

	}
}
