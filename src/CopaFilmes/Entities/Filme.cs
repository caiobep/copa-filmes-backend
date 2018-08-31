using System;
using System.Collections.Generic;

namespace CopaFilmes.Entities 
{
    public class Filme 
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public short? Ano { get; set; }
        public float Nota { get; set; }

        public static Movie ConvertToMovie(Filme filme)
        {
            return new Movie
            {
                Id = filme.Id,
                Title = filme.Titulo,
                Year = filme.Ano,
                Rating = filme.Nota
            };
        }
    }
}
