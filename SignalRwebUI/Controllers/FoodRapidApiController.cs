using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRwebUI.Dtos.RapidApiDtos;

namespace SignalRwebUI.Controllers
{
	public class FoodRapidApiController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=under_30_minutes"),
				Headers =
	{
		{ "x-rapidapi-key", "86bed023a1msha96b65a046a178bp1189f2jsnb705daedc9ab" },
		{ "x-rapidapi-host", "tasty.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				//var values = JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
				//return View(values.ToList());
				var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
				var values = root.Results;
				return View(values.ToList());

			}
		}
	}
}
