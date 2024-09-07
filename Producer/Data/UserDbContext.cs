using Microsoft.EntityFrameworkCore;

namespace Producer.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
              : base(options)
        {
        }
    }
}
