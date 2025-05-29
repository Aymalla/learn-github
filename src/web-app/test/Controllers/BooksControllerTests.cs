using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryManagementWebApp.Controllers;
using LibraryManagementWebApp.Models;
using Microsoft.Extensions.Logging;
using System;

namespace LibraryManagementWebApp.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTests
    {
        private readonly BooksController _controller;
        private readonly ILogger<BooksController> _logger;

        public BooksControllerTests()
        {
            _logger = new LoggerFactory().CreateLogger<BooksController>();
            _controller = new BooksController(_logger);
        }

        [TestMethod]
        public void Index_ReturnsViewResult_WithListOfBooks()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<Book>));
        }

        [TestMethod]
        public void Create_ValidBook_RedirectsToIndex()
        {
            // Arrange
            var book = new Book { Id = Guid.NewGuid().ToString(), Title = "Test Book", Author = "Author", ISBN = "1234567890", IsAvailable = true };

            // Act
            var result = _controller.Create(book);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod]
        public void Delete_ValidId_RedirectsToIndex()
        {
            var id = Guid.NewGuid().ToString();
            // Arrange
            var book = new Book { Id =id, Title = "Test Book", Author = "Author", ISBN = "1234567890", IsAvailable = true };
            _controller.Create(book);

            // Act
            var result = _controller.Delete(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod]
        public void Delete_InvalidId_RedirectsToIndex()
        {
            // Act
            var result = _controller.Delete("invalid-id");

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
    }
}
