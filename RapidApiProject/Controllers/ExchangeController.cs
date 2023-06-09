using Microsoft.AspNetCore.Mvc;

namespace RapidApiProject.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "630ce9cc86msh271c60cffe62d5ep1b514djsn0fe292593744" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ViewBag.v = body;
            }
            return View();
        }
    }
}
//Kur başlıkları bir enum liste üzeriden dropdown araçlarına aktarılsın
//1.dd neyden
//2.dd neye
//seçilen kurlara göre kur bilgisi getiren uygulamayı yazın.