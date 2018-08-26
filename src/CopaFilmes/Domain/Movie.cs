using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public Movie() 
        {
        }

        public Movie(string id, string title, int year, double rating)
        {
            Id = id;
            Title = title;
            Year = year;
            Rating = rating;
        }


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


                var winner = Movie.CompareMovies(firstMovie,  lastMovie);

                phase1Winners.Append(winner);
            }

            return phase1Winners.ToArray();
        }

        public static Movie[] EliminatoryFilter(Movie[] movies)
        {
            if ((movies.Length % 2) != 0)
                throw new Exception("movies itens must be in pairs");

            var moviesLinkedList = new LinkedList<Movie>(movies);
            var winners = new List<Movie>();

            for (int i = 0; i < moviesLinkedList.Count; i++)
            {
                var movieA = moviesLinkedList.First.Value;
                moviesLinkedList.RemoveFirst();

                var movieB = moviesLinkedList.First.Value;
                moviesLinkedList.RemoveFirst();

                var winner = Movie.CompareMovies(
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
            var firstPhaseWinners = Movie.GetFirstPhaseWinners(movies);
            
            Movie[] winners = null;
            while(winners.Length > 1)
            {
                winners = Movie.EliminatoryFilter(movies);
            }

            return winners.First();
        } 
    }
}
