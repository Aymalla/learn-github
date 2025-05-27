using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebApp.Models;

namespace LibraryManagementWebApp.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>();

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            books.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.IsAvailable = book.IsAvailable;
            }
            return RedirectToAction("Index");
        }
    }
}
