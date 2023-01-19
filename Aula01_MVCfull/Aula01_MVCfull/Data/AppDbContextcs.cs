using Aula01_MVCfull.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula01_MVCfull.Data
{
    public class AppDbContextcs : DbContext
    {
        public AppDbContextcs()
        {

        }
        public AppDbContextcs(DbContextOptions<AppDbContextcs> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-98JJ4C7; Initial Catalog = mvcfull; Integrated Security = true");

        }



        public DbSet<ContatoModel> contato { get; set; }
    }
}
