using Microsoft.EntityFrameworkCore;

namespace ComputersDAL
{
    public class ComputersContext : DbContext
    {
        public ComputersContext(DbContextOptions<ComputersContext> options) : base(options)
        {

        }

        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Monitor> Monitors { get; set; }
        public virtual DbSet<Printer> Printers { get; set; }
    }
}
