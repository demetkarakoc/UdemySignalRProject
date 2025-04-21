﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRwebUI.Dtos.CategoryDtos;
using System.Net.Http;

namespace SignalRwebUI.ViewComponents.MenuComponents
{
	public class _MenuCategoryFilterComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7286/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDtos>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
