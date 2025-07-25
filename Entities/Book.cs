using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice2.Entities.Base;

namespace Practice2.Entities
{
    public class Book : Thing
    {
        public required string Title { get; set; }
        public required string Writer { get; set; }
        public string? Translator { get; set; }
        public required string Publisher { get; set; }
        public string? Genre { get; set; }
        public double Price { get; set; }
    }
}