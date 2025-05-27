using Microsoft.AspNetCore.Mvc;
using LibraryManagementWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace LibraryManagementWebApp.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>();
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            _logger.LogInformation("Received IsAvailable value: {IsAvailable}", book.IsAvailable);

            if (ModelState.IsValid)
            {
                var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Author = book.Author;
                    existingBook.ISBN = book.ISBN;
                    existingBook.IsAvailable = book.IsAvailable;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete action called with id: {Id}", id);
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                _logger.LogInformation("Book with id {Id} removed successfully.", id);
            }
            else
            {
                _logger.LogWarning("Book with id {Id} not found.", id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
