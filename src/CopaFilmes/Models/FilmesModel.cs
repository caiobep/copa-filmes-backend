using System;
using System.Collections.Generic;
using CopaFilmes.Domain;

namespace CopaFilmes.Models 
{
    public class Filme 
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public float Nota { get; set; }


        public Movie ConvertToMovie() 
        {
            return new Movie
            {
                Id = Id,
                Title = Titulo,
                Year = Ano,
                Rating = Nota
            };
        }

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
