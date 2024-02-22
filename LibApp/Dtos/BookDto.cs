using LibApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LibApp.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public string Author { get; set; }

        public GenreDto Genre { get; set; }


        public byte GenreId { get; set; }


        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20, ErrorMessage = "Liczba w Magazynie musi być między 1 a 20.")]
        public int NumberInStock { get; set; }
    }
}