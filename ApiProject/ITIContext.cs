using ApiProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiProject
{
    public class ITIContext : IdentityDbContext<AppUser>
    {

        public ITIContext()
        {
                    
        }
        public ITIContext( DbContextOptions options) :base(options)
        {}

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
