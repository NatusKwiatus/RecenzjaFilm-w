namespace bazaDanych.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Opis { get; set; }

        public int? WpisId { get; set; }

        public Wpis Wpis { get; set; }


    }
}
