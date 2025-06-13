using bazaDanych.Models;
using bazaDanych.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bazaDanych.Services
{
    public class FilmService : IFilmService
    {
        private readonly BazaDbContext _db;

        public FilmService(BazaDbContext db)
        {
            _db = db;
        }
        public async Task<List<Film>> WszystkieFilmy()
        {
            return await _db.Filmy
                .Include(f => f.Wpis)
                .ToListAsync();
        }

        public async Task DodajOcene(Wpis wpis)
        {
            _db.Wpisy.Add(wpis);
            await _db.SaveChangesAsync();
        }
        public async Task UsunOcene(int wpisId)
        {
            var wpis = await _db.Wpisy.FindAsync(wpisId);

            if (wpis != null)
            {
                // znajdź film powiązany z tym wpisem
                var film = await _db.Filmy.FirstOrDefaultAsync(f => f.WpisId == wpisId);

                if (film != null)
                {
                    film.WpisId = null; // odłącz wpis od filmu
                    _db.Filmy.Update(film);
                    await _db.SaveChangesAsync();
                }

                _db.Wpisy.Remove(wpis);
                await _db.SaveChangesAsync();
            }
        }
        public async Task EdytujOcene(Wpis wpis)
        {
            var ocena = await _db.Wpisy.FindAsync(wpis.Id);
            if (ocena != null)
            {
                ocena.Ocena = wpis.Ocena;
                ocena.Recenzje = wpis.Recenzje;



                await _db.SaveChangesAsync();
            }
        }
        public async Task<Wpis> PobierzOcenePoId(int id)
        {
            return await _db.Wpisy.FindAsync(id);
        }

    }
}
