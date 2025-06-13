using bazaDanych.Models;
using Microsoft.AspNetCore.Mvc;
using bazaDanych.Services.Interfaces;
using System.Diagnostics;
using bazaDanych.Services;

namespace bazaDanych.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> Index()
        {
            var filmy = await _filmService.WszystkieFilmy();
            return View(filmy);
        }

        [HttpPost]
        public async Task<IActionResult> UsunOcene(int wpisId)
        {
            await _filmService.UsunOcene(wpisId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DodajOcene(int filmId)
        {
            ViewBag.FilmId = filmId;
            return View(new Wpis());
        }

        [HttpPost]
        public async Task<IActionResult> DodajOcene(Wpis Wpis)
        {
            if (ModelState.IsValid)
            {
                await _filmService.DodajOcene(Wpis);
                return RedirectToAction("Index");
            }

            return View(Wpis);
        }
        [HttpGet]
        public async Task<IActionResult> EdytujOcene(int id)
        {
            // Pobierz ocen� (Wpis) o podanym id
            var ocenaDoEdycji = await _filmService.PobierzOcenePoId(id);

            if (ocenaDoEdycji == null)
            {
                // Je�li nie ma takiej oceny, zwr�� 404
                return NotFound();
            }

            // Przeka� model do widoku, aby u�ytkownik m�g� edytowa�
            return View(ocenaDoEdycji);
        }

        [HttpPost]
        public async Task<IActionResult> EdytujOcene(Wpis wpis)
        {
            if (!ModelState.IsValid)
            {
                // Je�li model jest niepoprawny, wr�� do widoku z b��dami
                return View(wpis);
            }

            // Zapisz zmiany w ocenie
            await _filmService.EdytujOcene(wpis);

            // Po zapisaniu przekieruj na stron� g��wn� (lub inn�)
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
