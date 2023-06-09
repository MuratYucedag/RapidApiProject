using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieListViewModel> apiMovieListViewModels = new List<ApiMovieListViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMovieListViewModels = JsonConvert.DeserializeObject<List<ApiMovieListViewModel>>(body);
                return View(apiMovieListViewModels);
            }
        }
    }
}
