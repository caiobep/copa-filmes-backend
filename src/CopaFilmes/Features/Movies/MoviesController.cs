using System;
using System.Collections.Generic;
using System.Net.Http;
using CopaFilmes.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Infrastructure;

namespace CopaFilmes.Features.Movies 
{

    [Route("/api/Movies")]
    public class MoviesController : Controller
    {   
        private MoviesRepository _moviesRepository = new MoviesRepository();

        [HttpGet]
        public async Task<Movie[]> Get()
        {
            var movies = await _moviesRepository.GetMoviesFromApi();
            return movies;
        }

    }
}