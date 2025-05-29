using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWebApp.Models
{
    public class Book
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(13)]
        public string ISBN { get; set; }

        public bool IsAvailable { get; set; }
    }
}
