using System;
using System.Collections.Generic;
using System.Net.Http;
using CopaFilmes.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Repositories;

namespace CopaFilmes.Features.Movies 
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/Movies")]
    public class MoviesController : Controller
    {   
        private MoviesRepository _moviesRepository = new MoviesRepository();

        [HttpGet]
        public async Task<Movie[]> Get()
        {
            var movies = await _moviesRepository.GetMoviesFromApi();
            return movies;
        }

        [HttpPost("Tournament")]
        public Movie GetTournamentWinner([FromBody] Movie[] movies)
        {
            var winner = MovieExtensions.GetTournamentWinner(movies);
            return winner;
        }

    }
}
