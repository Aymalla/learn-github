using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Models;
using System.Collections.Generic;
using Xunit;

namespace LibraryManagementWebApp.Tests
{
    public class BooksControllerTests
    {
        private readonly BooksController _controller;
        private readonly ILogger<BooksController> _logger;

        public BooksControllerTests()
        {
            _logger = new LoggerFactory().CreateLogger<BooksController>();
            _controller = new BooksController(_logger);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithListOfBooks()
        {
            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<List<Book>>(viewResult.Model);
        }

        [Fact]
        public void Create_ValidBook_RedirectsToIndex()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "1234567890", IsAvailable = true };

            // Act
            var result = _controller.Create(book);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test Book", Author = "Author", ISBN = "1234567890", IsAvailable = true };
            _controller.Create(book);

            // Act
            var result = _controller.Delete(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Delete_InvalidId_RedirectsToIndex()
        {
            // Act
            var result = _controller.Delete(999);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
