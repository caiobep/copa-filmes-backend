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
                Year = new DateTime(1999),
                Rating = 8.7
            };
            
            var fightClub = new Movie
            {
                Id = "t0002",
                Title = "Fight Club",
                Year = new DateTime(1999),
                Rating = 8.8
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
                Year = new DateTime(1977),
                Rating = 8.6
            };

            var cityOfGod = new Movie
            {
                Id = "t0002",
                Title = "City Of God",
                Year = new DateTime(2002),
                Rating = 8.6
            };


            var alphabeticalyWinner = MovieExtensions.CompareMovies(
                starWars,
                cityOfGod
            );


            Assert.Equal(alphabeticalyWinner, cityOfGod);
        }
    }
}
