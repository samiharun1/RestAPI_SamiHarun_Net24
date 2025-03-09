using Microsoft.EntityFrameworkCore;

namespace RestAPI_SamiHarun_Net24.Models.Data
{
    public class CvDBContext : DbContext
    {
        public CvDBContext(DbContextOptions<CvDBContext> options) : base(options)
        {


            
        }

        public DbSet<Person> Personer { get; set; }
        public DbSet<Utbildning> Utbildningar { get; set; }
        public DbSet<Erfarenhet> Erfarenheter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Utbildningar)
                .WithOne(u => u.Person)
                .HasForeignKey(u => u.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Erfarenheter)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId);


            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Namn = "Sami Harun", Beskrivning = "Fullstack .NET utvecklare", KontaktInfo = "sami@example.com" }
    );

            
            modelBuilder.Entity<Utbildning>().HasData(
                new Utbildning { Id = 1, Skola = "Chalmers Tekniska Högskola", Examen = "Civilingenjör", StartDatum = new DateTime(2015, 8, 15), SlutDatum = new DateTime(2020, 6, 10), PersonId = 1 }
            );

            
            modelBuilder.Entity<Erfarenhet>().HasData(
                new Erfarenhet { Id = 1, JobTitel = "Software Developer", Företag = "Spotify", År = 2021, PersonId = 1 }
            );
        }
    }
}

