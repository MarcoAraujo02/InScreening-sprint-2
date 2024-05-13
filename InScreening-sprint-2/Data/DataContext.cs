
using Microsoft.EntityFrameworkCore;

namespace InScreening_sprint_2.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Triagem> Triagem { get; set; }
     

    }
}

