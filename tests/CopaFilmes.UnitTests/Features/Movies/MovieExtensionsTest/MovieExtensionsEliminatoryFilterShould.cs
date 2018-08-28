using System;
using System.Collections.Generic;
using Xunit;
using CopaFilmes.Entities;
using CopaFilmes.Features.Movies;

namespace CopaFilmes.UnitTests.Features.Movies.MovieExtensionsTest
{
    public class MovieExtensionsEliminatoryFilterShould
    {
        [Fact]
        public void ReturnFilterdMovies()
        {
            var movies = new Movie[]
            {
                MoviesMock.vingadoresGuerraInfinita,
                MoviesMock.thorRagnarok,
                MoviesMock.osIncriveis2,
                MoviesMock.jurassicWorldReinoAmeaçado
            };

            var expectedWinners = new Movie[]
            {
                MoviesMock.vingadoresGuerraInfinita,
                MoviesMock.osIncriveis2
            };


            var actualWinners = MovieExtensions.EliminatoryFilter(movies);
        
        
            Assert.Equal(expectedWinners, actualWinners);
        }
    }
}
