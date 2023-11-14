using Microsoft.EntityFrameworkCore;
using WEb_PhysicalPerson_API.Models;

namespace WEb_PhysicalPerson_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ConnectedPerson> ConnectedPersons { get; set; }
       
    }
}
