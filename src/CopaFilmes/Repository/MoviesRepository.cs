using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CopaFilmes.Domain;
using CopaFilmes.Models;
using Newtonsoft.Json;

namespace CopaFilmes.Repository 
{
    public class MoviesRepository
    {
        private HttpClient _client = new HttpClient();

        public MoviesRepository()
        {
            _client.BaseAddress = new Uri(
                "http://copafilmes.azurewebsites.net/"
            );

            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(
                    "application/json"
                )
            );
        }

        public async Task<List<Movie>> GetMoviesFromApi()
        {
            var response = await _client.GetAsync("api/filmes");

            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                var rawMovies = JsonConvert
                    .DeserializeObject<Filme[]>(stringResult);

                var movies = rawMovies.Select(m => m.ConvertToMovie());
                return movies.ToList();
            }

            return new List<Movie>();
        }
    }
}
