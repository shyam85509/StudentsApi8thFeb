using Microsoft.EntityFrameworkCore;

namespace stdapi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Studentsdata> Studentsdata { get; set; }
    }
}
