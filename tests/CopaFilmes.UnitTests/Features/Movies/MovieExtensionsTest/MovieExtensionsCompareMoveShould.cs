using System;
using System.Collections.Generic;
using Xunit;
using CopaFilmes.Entities;
using CopaFilmes.Features.Movies;

namespace CopaFilmes.UnitTests.Features.Movies.MovieExtensionsTest
{
    public class MovieExtensionsCompareMoveShould
    {
        [Fact]
        public void ReturnMovieWithHighestScore()
        {
            var theMatrix = new Movie
            {
                Id = "t0001",
                Title = "The Matrix",
                Year = 1999,
                Rating = 8.7f
            };
            
            var fightClub = new Movie
            {
                Id = "t0002",
                Title = "Fight Club",
                Year = 1999,
                Rating = 8.8f
            };


            var winner = MovieExtensions.CompareMovies(theMatrix, fightClub);
            var winner2 = MovieExtensions.CompareMovies(fightClub, theMatrix);


            Assert.Equal(winner, winner2);
            Assert.Equal(fightClub, winner);
        }

        [Fact]
        public void ReturnMovieWithAplhabeticallyPriority()
        {
            var starWars = new Movie
            {
                Id = "t0001",
                Title = "Star Wars",
                Year = 1977,
                Rating = 8.6f
            };

            var cityOfGod = new Movie
            {
                Id = "t0002",
                Title = "City Of God",
                Year = 2002,
                Rating = 8.6f
            };


            var alphabeticalyWinner = MovieExtensions.CompareMovies(
                starWars,
                cityOfGod
            );


            Assert.Equal(alphabeticalyWinner, cityOfGod);
        }
    }
}
