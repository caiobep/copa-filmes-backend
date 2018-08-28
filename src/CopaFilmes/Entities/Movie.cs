using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CopaFilmes.Entities
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? Year { get; set; }
        public double? Rating { get; set; }
    }
}
