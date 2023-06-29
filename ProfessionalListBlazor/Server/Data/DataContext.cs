
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
                new Style { Id = 1, Name = "Home Office" },
                new Style { Id = 2, Name = "Company" }
              );

            modelBuilder.Entity<ProfessionalList>().HasData(
                new ProfessionalList
                {
                    Id = 1,
                    Name = "Janne",
                    Position = "Senior",
                    StyleId = 1
                },

                new ProfessionalList
                {
                    Id = 2,
                    Name = "John",
                    Position = "Treinee",
                    StyleId = 2
                }
             );
        }        

            public DbSet<ProfessionalList> ProfessionalLists { get; set;}
            public DbSet<Style> Styles {get; set;}

        

    }
}
