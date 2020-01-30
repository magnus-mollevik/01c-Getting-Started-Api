using Entertainment.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Entertainment.DataAccess
{
    public class EntertainmentContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "Api.Database",
                IntegratedSecurity = true
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString.ToString());
        }

        public EntertainmentContext(DbContextOptions<EntertainmentContext> options) : base(options) { }

        public EntertainmentContext()
        {
        }
    }
}