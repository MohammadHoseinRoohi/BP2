using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice2.DTOs.Books
{
    public class BookListDto
    {
        public string? Id { get; set; }
        public required string Title { get; set; }
        public required string Writer { get; set; }
        public string? Translator { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public double Price { get; set; }
    }
}