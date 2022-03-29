using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using PhoneBook.Authorization.Roles;
using PhoneBook.Authorization.Users;
using PhoneBook.MultiTenancy;
using PhoneBook.PhoneBook.Persons;
using PhoneBook.PhoneBook.PhoneNumbers;

namespace PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PhoneNumber> PhoneNumber { get; set; }
    }
}
