using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CopaFilmes.Entities;
using CopaFilmes.Features.Movies;
using CopaFilmes.UnitTests.Features.Movies;

namespace CopaFilmes.UnitTests.Features.Movies.MovieExtensionsTest
{
    public class MovieExtensionsGetFirstPhaseWinnersShould
    {

        [Fact]
        public void ReturnFirstPhaseWinners()
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

            var expectedWinners = new Movie[] 
            {
                MoviesMock.vingadoresGuerraInfinita,
                MoviesMock.thorRagnarok,
                MoviesMock.osIncriveis2,
                MoviesMock.jurassicWorldReinoAmeaçado
            };


            var winners = MovieExtensions.GetFirstPhaseWinners(movies);

            
            Assert.Equal(winners, expectedWinners);
        }
    }
}
