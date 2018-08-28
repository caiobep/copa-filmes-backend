using System;
using System.Collections.Generic;
using Xunit;
using CopaFilmes.Entities;
using CopaFilmes.Features.Movies;

namespace CopaFilmes.UnitTests.Features.Movies.MovieExtensionsTest
{
    public class MovieExtensionsGetTournamentWinnerShould
    {
        [Fact]
        public void ReturnWinner()
        {
            var movies = new Movie[]
            {
                MoviesMock.osIncriveis2,
                MoviesMock.jurassicWorldReinoAmeaçado,
                MoviesMock.oitoMulheresEUmSegredo,
                MoviesMock.hereditario,
                MoviesMock.vingadoresGuerraInfinita,
                MoviesMock.deadpool2,
                MoviesMock.hanSoloUmaHistoriaStarWars,
                MoviesMock.thorRagnarok
            };

            var expectedWinner = MoviesMock.vingadoresGuerraInfinita;

        
            var winner = MovieExtensions.GetTournamentWinner(movies);

            Assert.Equal(expectedWinner, winner);
        }
    }
}
