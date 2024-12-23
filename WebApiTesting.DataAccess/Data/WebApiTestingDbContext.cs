using Microsoft.EntityFrameworkCore;
using WebApiTesting.Entities;

namespace WebApiTesting.DataAccess.Data
{
    public class WebApiTestingDbContext : DbContext
    {
         public WebApiTestingDbContext(DbContextOptions<WebApiTestingDbContext> opt) : base(opt) { }

        public DbSet<User> Users { get; set; }

    }
}
