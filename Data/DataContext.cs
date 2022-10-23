using Microsoft.EntityFrameworkCore;
using One_Time_Password_Generator.Entities;

namespace One_Time_Password_Generator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users{ get; set; }
    }
}
