using System;
using System.Collections.Generic;
using CopaFilmes.Entities;

namespace CopaFilmes.Models.Tournament 
{
    public class TournamentWinners
    {
        public Movie Winner { get; set; }
        public Movie RunnerUp { get; set; }


        public TournamentWinners(Movie winner, Movie runnerUp)
        {
            Winner = winner;
            RunnerUp = runnerUp;
        }
    }
}
