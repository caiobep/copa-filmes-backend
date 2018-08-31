using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Entities;
using Newtonsoft.Json;

namespace CopaFilmes.Repositories 
{
    public class MoviesRepository : IMovieRepository
    {
        private readonly HttpClient _client;

        public MoviesRepository(IHttpClientFactory client)
        {
            _client = client.CreateClient("CopaFilmes");
        }

        public async Task<Movie[]> GetMoviesFromApi()
        {
            var response = await _client.GetAsync("api/filmes");

            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                var rawMovies = JsonConvert
                    .DeserializeObject<Filme[]>(stringResult);

                var movies = rawMovies.Select(m => Filme.ConvertToMovie(m));
                return movies.ToList().ToArray();
            }

            return new List<Movie>().ToArray();
        }
    }
}
