namespace TempAPI.DBContext
{
    public class TempContext : DbContext
    {
        public TempContext(DbContextOptions<TempContext> options) : base(options)
        {
        }

        public DbSet<Measurment> Measurements { get; set; }

    }
}
