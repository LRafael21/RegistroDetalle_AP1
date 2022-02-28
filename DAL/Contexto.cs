using Microsoft.EntityFrameworkCore;
using BLAZORREGISTRO.Entidades;


namespace BLAZORREGISTRO.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            optionsBuilder.UseSqlite(@"Data Source = Data\\Luis_Baltodano_Ap1_p1.db");

         
        }
        
    }
}
