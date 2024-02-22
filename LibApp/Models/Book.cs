using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [Required(ErrorMessage = "Pole Tytuł jest wymagane.")]

        public string Author { get; set; }
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Pole Id Gatunku jest wymagane.")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Pole Data Dodania jest wymagane.")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Pole Data Wydania jest wymagane.")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Pole Liczba w Magazynie jest wymagane.")]
        [Range(1, 20, ErrorMessage = "Liczba w Magazynie musi być między 1 a 20.")]
        public int NumberInStock { get; set; }
    }
}