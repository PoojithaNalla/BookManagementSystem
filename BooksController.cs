// using Microsoft.AspNetCore.Mvc;
// using BookAPI.Models;
// using BookManagementSystem.Data;
// using Microsoft.EntityFrameworkCore;

// namespace BookAPI.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class BooksController : ControllerBase
//     {
//         private readonly AppDbContext _context;

//         public BooksController(AppDbContext context)
//         {
//             _context = context;
//         }

//         // ✅ GET all books
//         [HttpGet]
//         public async Task<IActionResult> GetAll()
//         {
//             var books = await _context.Books.ToListAsync();
//             return Ok(books);
//         }

//         // ✅ GET by id
//         [HttpGet("{id}")]
//         public async Task<IActionResult> Get(int id)
//         {
//             var book = await _context.Books.FindAsync(id);
//             if (book == null) return NotFound();

//             return Ok(book);
//         }

//         // ✅ ADD book
//         [HttpPost]
//         public async Task<IActionResult> Create(Book book)
//         {
//             _context.Books.Add(book);
//             await _context.SaveChangesAsync();

//             return Ok(book);
//         }

// // ✅ UPDATE BOOK
// [HttpPut("{id}")]
// public async Task<IActionResult> Update(int id, Book updatedBook)
// {
//     var book = await _context.Books.FindAsync(id);

//     if (book == null)
//         return NotFound();

//     // Update fields
//     book.Title = updatedBook.Title;
//     book.Author = updatedBook.Author;
//     book.Price = updatedBook.Price;

//     await _context.SaveChangesAsync();

//     return Ok(book);
// }
//         // ✅ DELETE
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete(int id)
//         {
//             var book = await _context.Books.FindAsync(id);
//             if (book == null) return NotFound();

//             _context.Books.Remove(book);
//             await _context.SaveChangesAsync();

//             return Ok("Deleted");
//         }
//     }
// }




using Microsoft.AspNetCore.Mvc;
using BookAPI.Models;
using BookManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET all books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        // ✅ GET by id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound(new { message = "Book not found" });

            return Ok(book);
        }

        // ✅ ADD book
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // ✅ UPDATE BOOK
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Book updatedBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound(new { message = "Book not found" });

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;

            await _context.SaveChangesAsync();

            return Ok(book);
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound(new { message = "Book not found" });

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Book deleted successfully" });
        }
    }
}