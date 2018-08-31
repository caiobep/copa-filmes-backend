using System;
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
            if ((movies.Count() % 2) != 0)
                return new Movie[] { };


            var organizedMovies = movies.OrderBy(m => m.Title);
            
            var movieLinkedList = new LinkedList<Movie>(organizedMovies);
            
            var winners = new List<Movie>();
            
            while (movieLinkedList.Count > 0)
            {
                var firstMovie = movieLinkedList.First.Value;
                movieLinkedList.RemoveFirst();

                var lastMovie = movieLinkedList.Last.Value;
                movieLinkedList.RemoveLast();

                var winner = CompareMovies(firstMovie, lastMovie);
            
                winners.Add(winner);
            }

            return winners.ToArray();

        }

        public static Movie[] EliminatoryFilter(Movie[] movies)
        {
            if ((movies.Count() % 2) != 0)
                return new Movie[] { };

            var moviesLinkedList = new LinkedList<Movie>(movies);
            
            var winners = new List<Movie>();

            while(moviesLinkedList.Count > 0)
            {
                var movieA = moviesLinkedList.First.Value;
                moviesLinkedList.RemoveFirst();

                var movieB = moviesLinkedList.First.Value;
                moviesLinkedList.RemoveFirst();

                var winner = CompareMovies(
                    movieA,
                    movieB
                );
                
                winners.Add(winner);
            }

            return winners.ToArray();
        }

        public static (Movie Winner, Movie RunnerUp) GetTournamentWinners(Movie[] movies)
        {
            var firstPhaseWinners = GetFirstPhaseWinners(movies);

            Movie[] winners = firstPhaseWinners;
            while(winners.Length > 2)
            {
                winners = EliminatoryFilter(winners);
            }

            var winner = CompareMovies(winners.First(), winners.Last());
            var runnerUp = winners.Single(m => m.Id != winner.Id);

            return (winner, runnerUp);
        } 
    }
}
