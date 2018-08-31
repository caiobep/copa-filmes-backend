using System;
using System.Collections.Generic;
using System.Net.Http;
using CopaFilmes.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CopaFilmes.Repositories;
using CopaFilmes.Models.Tournament;

namespace CopaFilmes.Features.Movies 
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/Movies")]
    public class MoviesController : Controller
    {   
        private readonly IMovieRepository _moviesRepository;

        public MoviesController(IMovieRepository movieReposiotry)
        {
            _moviesRepository = movieReposiotry;
        }

        [HttpGet]
        public async Task<Movie[]> Get()
        {
            var movies = await _moviesRepository.GetMoviesFromApi();
            return movies;
        }

        [HttpPost("Tournament")]
        public TournamentWinners GetTournamentWinner([FromBody] Movie[] movies)
        {
            var winners = MovieExtensions.GetTournamentWinners(movies);
            return new TournamentWinners(winners.Winner, winners.RunnerUp);
        }

    }
}
