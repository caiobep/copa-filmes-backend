using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public Movie() 
        {
        }
    }
}
