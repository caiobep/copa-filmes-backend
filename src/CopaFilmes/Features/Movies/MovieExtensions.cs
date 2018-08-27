using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Entities;

namespace CopaFilmes.Features.Movies
{
    public class MovieExtensions
    {
        public static Movie CompareMovies(Movie movieA, Movie movieB)
        {
            if (movieA.Rating == movieB.Rating)
            {
                var alphabeticalWinner = new List<Movie>() { movieA, movieB }
                    .OrderBy(p => p.Title)
                    .First();

                return alphabeticalWinner;
            }

            return (movieA.Rating > movieB.Rating) ? movieA : movieB;
        }

        public static Movie[] GetFirstPhaseWinners(Movie[] movies)
        {
            var movieLinkedList = new LinkedList<Movie>(movies);
            var phase1Winners = new List<Movie>();

            for (int i = 0; i < movieLinkedList.Count; i++)
            {
                var firstMovie = movieLinkedList.First.Value;
                movieLinkedList.RemoveFirst();

                var lastMovie = movieLinkedList.Last.Value;
                movieLinkedList.RemoveLast();


                var winner = CompareMovies(firstMovie,  lastMovie);

                phase1Winners.Append(winner);
            }

            return phase1Winners.ToArray();
        }

        public static Movie[] EliminatoryFilter(Movie[] movies)
        {
            var moviesLinkedList = new LinkedList<Movie>(movies);
            var winners = new List<Movie>();

            for (int i = 0; i < moviesLinkedList.Count; i++)
            {
                var movieA = moviesLinkedList.First.Value;
                moviesLinkedList.RemoveFirst();

                var movieB = moviesLinkedList.First.Value;
                moviesLinkedList.RemoveFirst();

                var winner = CompareMovies(
                    movieA,
                    movieB
                );
                
                winners.Append(winner);
            }

            return winners.ToArray();
        }

        public static Movie GetTournamentWinner(Movie[] movies)
        {
            movies.OrderBy(m => m.Title);
            var firstPhaseWinners = GetFirstPhaseWinners(movies);
            
            Movie[] winners = null;
            while(winners.Length > 1)
            {
                winners = EliminatoryFilter(movies);
            }

            return winners.First();
        } 
    }
}
