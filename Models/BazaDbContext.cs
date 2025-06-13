using Microsoft.EntityFrameworkCore;

namespace bazaDanych.Models
{
    public class BazaDbContext : DbContext
    {
        public BazaDbContext(DbContextOptions<BazaDbContext> options) : base(options)
        { }


        public DbSet<Film> Filmy { get; set; }
        public DbSet<Wpis> Wpisy { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
    .HasOne(f => f.Wpis)
    .WithMany()
    .HasForeignKey(f => f.WpisId)
    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, Tytul = "Lilo i stich", Opis = "Dziewczynka zaprzyjaznia sie z kosmita", WpisId = 1},
                new Film { Id = 2, Tytul = "Igrzyska Śmierci", Opis = " 24 nastolatkowie walcza na smierc i zycie umieraja ", WpisId = 2 },
                new Film { Id = 3, Tytul = "Alwin i Wiewiórki", Opis = "O 3 wiewiorkach ktore spiewaja ", WpisId = 3},
                new Film { Id = 4, Tytul = "Infinity war", Opis = "Bohaterowie proboja powstrzymac zagrozenie na skale wszechswiata", WpisId = 4 }
            );

            modelBuilder.Entity<Wpis>().HasData(
                new Wpis { Id = 1, Ocena = 7, Recenzje = "Fajne" },
                new Wpis { Id = 2, Ocena = 10, Recenzje = "Mega mocne" },
                new Wpis { Id = 3, Ocena = 2, Recenzje = "Slabe" },
                new Wpis { Id = 4, Ocena = 5, Recenzje = "Moze byc" }
            );

        }
    }
}
