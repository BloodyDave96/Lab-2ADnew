using LibApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace LibApp.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

    }
}