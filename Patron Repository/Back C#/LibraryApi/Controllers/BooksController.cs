using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.interfaces;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bookRepository.AddBook(newBook);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookToUpdate = _bookRepository.GetBookById(id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }

            updatedBook.Id = id;
            _bookRepository.UpdateBook(updatedBook);
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bookToDelete = _bookRepository.GetBookById(id);
            if (bookToDelete == null)
            {
                return NotFound();
            }

            _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
