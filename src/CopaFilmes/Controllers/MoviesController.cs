using System;
using System.Collections.Generic;
using System.Net.Http;
using CopaFilmes.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Repository;

namespace CopaFilmes.Controllers 
{

    [Route("/api/[controller]")]
    public class MoviesController : Controller
    {   
        private MoviesRepository _moviesRepository = new MoviesRepository();

        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            var movies = await _moviesRepository.GetMoviesFromApi();
            return movies;
        }
    }
}
