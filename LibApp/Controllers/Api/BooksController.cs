using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LibApp.Models;
using LibApp.Dtos;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public BooksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        // GET /api/books
        //[HttpGet]
        //public IActionResult GetBooks()
        //{
        //    return Ok(_context.Books
        //        .Include(b => b.Genre)
        //        .ToList()
        //        .Select(_mapper.Map<Book, BookDto>));
        //}

        // GET /api/books/{id}
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books
                .Include(b => b.Genre)
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Book, BookDto>(book));
        }


        [HttpPost]
        public IActionResult CreateBook([FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<BookDto, Book>(bookDto);
            book.DateAdded = DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, bookDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}