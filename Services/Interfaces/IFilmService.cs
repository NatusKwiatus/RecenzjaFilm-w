using bazaDanych.Models;

namespace bazaDanych.Services.Interfaces
{
    public interface IFilmService
    {
        Task<List<Film>> WszystkieFilmy();
        Task UsunOcene(int wpisId);
        Task DodajOcene(Wpis wpis);
        Task EdytujOcene(Wpis wpis);
        Task<Wpis> PobierzOcenePoId(int id);
    }
}
