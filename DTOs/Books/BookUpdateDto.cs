using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2.DTOs.Books
{
    public class BookUpdateDto
    {
        public string? Title { get; set; }
        public string? Writer { get; set; }
        public string? Translator { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public double Price { get; set; }
    }
}