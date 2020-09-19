using Microsoft.EntityFrameworkCore;
using Registro_Completo.Entidades;

namespace Registro_Completo.Dal{

    public class Contexto: DbContext{
        
        public DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            optionsBuilder.UseSqlite(@"Data Source = Persona.db");
        }
    }
}