using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Entities;

namespace CopaFilmes.Repositories 
{
    public interface IMovieRepository
    {
        Task<Movie[]> GetMoviesFromApi();
    }
}
