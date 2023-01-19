using API_MYSQL.Model;
using Microsoft.EntityFrameworkCore;

namespace API_MYSQL.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Alunos> alunos { get; set; }
        public DbSet<Professor> professores { get; set; }
        public DbSet<Materias> materias { get; set; }
    }
}
