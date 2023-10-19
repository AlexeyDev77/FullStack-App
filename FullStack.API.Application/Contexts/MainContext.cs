using FullStack.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Application.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }
    }
}


