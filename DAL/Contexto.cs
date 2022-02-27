using Microsoft.EntityFrameworkCore;
using Blazor.Entidades;

namespace Blazor.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite(@"Data Source=DATA/Luis_Baltodano_Ap1_p1.db");
        }
    }
}
