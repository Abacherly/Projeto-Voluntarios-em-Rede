
using ProfessionalListBlazor.Shared;
using System.Xml.Linq;

namespace ProfessionalListBlazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Style>().HasData(
                new Style { Id = 1, Name = "Sim" },
                new Style { Id = 2, Name = "Não" }
              );

            modelBuilder.Entity<ProfessionalList>().HasData(
                new ProfessionalList
                {
                    Id = 1,
                    Name = "Marisa Aparecida - Enfermeira",
                    Position = "(11)974836354 / Penha-Zona Leste, São Paulo",
                    StyleId = 1
                },

                new ProfessionalList
                {
                    Id = 2,
                    Name = "João Carlos - Psicólogo",
                    Position = "(11)937264738 / Tucuruvi - Zona Norte, São Paulo",
                    StyleId = 2
                }
             );
        }        

            public DbSet<ProfessionalList> ProfessionalLists { get; set;}
            public DbSet<Style> Styles {get; set;}

        

    }
}
